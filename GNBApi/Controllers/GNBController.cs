using GNBApi.Model;
using GNBApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GNBApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class GNBController : ControllerBase
    {

        private readonly IGNBService _ignbservice;

        private List<Transaction> _transactions = new List<Transaction>();

        public GNBController(IGNBService ignbservice)
        {
            _ignbservice = ignbservice;
        }


        //public IActionResult Get() => Ok(_ignbservice.GetAllTransactions("a"));
        [HttpGet("GetTransactionsAsync")]
        public async Task<List<Transaction>> GetAllTransactionsSKU()
        {
            return await _ignbservice.GetAllTransactions("a");
        }

        //private async Task<List<GithubInfo>> GetPRsPerUser()
        //{
        //    List<PullRequest> pullRequests = new List<PullRequest>();

        //    _repositories = await _githubService.GetRepositories(EvaluatorLink);
        //    var exercises = _repositories.Where(x => x.Name.Contains("Ejer")).ToList();
        //    foreach (var exer in exercises)
        //    {
        //        pullRequests.AddRange(await _githubService.GetPullRequests(EvaluatorLink, exer.Name));
        //    }

        //    return pullRequests.GroupBy(x => x.User.Login)
        //        .Select(x => new GithubInfo() { User = x.Key, PullRequests = x.ToList() }).ToList();
        //}


    }
}
