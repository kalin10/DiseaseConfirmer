namespace DiseaseConfirmer.Web
{
    using System.Reflection;
    using CloudinaryDotNet;
    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Data.Common;
    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Data.Repositories;
    using DiseaseConfirmer.Data.Seeding;
    using DiseaseConfirmer.Services;
    using DiseaseConfirmer.Services.Contracts;
    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using DiseaseConfirmer.Services.Messaging;
    using DiseaseConfirmer.Web.Hubs;
    using DiseaseConfirmer.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            services.AddSignalR();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Add cloudinary
            var cloudinary = new Cloudinary(new Account()
            {
                Cloud = this.configuration["CloudinarySettings:CloudName"],
                ApiKey = this.configuration["CloudinarySettings:ApiKey"],
                ApiSecret = this.configuration["CloudinarySettings:ApiSecret"],
            });
            services.AddSingleton(cloudinary);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IDiseasesService, DiseasesService>();
            services.AddTransient<IInquiriesService, InquiriesService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICareersInfoService, CareersInfoService>();
            services.AddTransient<IDoctorsService, DoctorsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IProfilePictureService, ProfilePictureService>();
            services.AddTransient<IVotesService, VotesService>();
            services.AddTransient<IComplaintsService, ComplaintsService>();
            services.AddTransient<IMessagesService, MessagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapHub<ChatHub>("/chat");
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("categories", "Category/{name:minlength(4)}", new { controller = "Categories", action = "ByName" });
                        endpoints.MapControllerRoute("doctorsByCategories", "Doctors/DoctorsInCategory/{categoryName:minlength(3)}", new { controller = "Doctors", action = "DoctorsInCategory" });
                        endpoints.MapControllerRoute("addDisease", "Diseases/{categoryName:minlength(3)}/Add", new { controller = "Diseases", action = "Add" });
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
