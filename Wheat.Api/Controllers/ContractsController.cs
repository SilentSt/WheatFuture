using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wheat.Api.Service;
using Wheat.DataLayer.Repositories.Interfaces;
using Wheat.Models.Requests;

namespace Wheat.Api.Controllers
{
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContractsController : ControllerExt
    {
        private readonly IContractRepository _contracts;
        public ContractsController(IContractRepository contracts)
        {
            _contracts = contracts;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _contracts.GetMyContractsAsync(UserId);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostContractsRequest request)
        {
            await _contracts.CreateContractsAsync(UserId, request.Count, request.Price);
            return Ok();
        }
    }
}
