namespace DiseaseConfirmer.Web.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVotesService votesService,
            UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Post(VoteInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.votesService.VoteAsync(inputModel.DiseaseId, user.Id, inputModel.IsUpVote);

            var votes = this.votesService.GetVotes(inputModel.DiseaseId);
            VoteResponseModel voteResponseModel = new VoteResponseModel
            {
                VotesCount = votes,
            };

            return voteResponseModel;
        }
    }
}
