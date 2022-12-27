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
        public GNBController(IGNBService ignbservice)
        {
            _ignbservice = ignbservice;
        }


        [HttpGet("GetTransactions")]
        public async Task<List<Transaction>> GetAllTransactionsSKU()
        {
            return await _ignbservice.GetAllTransactions("GetSKU");
        }

        [HttpGet("GetRates")]
        public async Task<List<Rate>> GetAllRates()
        {
            return await _ignbservice.GetAllRates("GetRates");
        }

        [HttpGet("GetSKUTransactions")]
        public async Task<List<Transaction>> GetSKUTransactions([FromQuery] string SKU)
        {
            return await _ignbservice.GetSKUTransactions("GetSKU", SKU);
        }

    }
}
