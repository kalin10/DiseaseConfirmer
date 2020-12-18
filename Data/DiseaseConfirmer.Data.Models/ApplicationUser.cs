// ReSharper disable VirtualMemberCallInConstructor
namespace DiseaseConfirmer.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DiseaseConfirmer.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Inquiries = new HashSet<Inquiry>();
            this.Comments = new HashSet<Comment>();
            this.Messages = new HashSet<Message>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        // Custom
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ProfilePictureId { get; set; }

        public ProfilePicture ProfilePicture { get; set; }

        // Doctor
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? CareerInfoId { get; set; }

        public virtual CareerInfo CareerInfo { get; set; }

        public virtual ICollection<Inquiry> Inquiries { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
