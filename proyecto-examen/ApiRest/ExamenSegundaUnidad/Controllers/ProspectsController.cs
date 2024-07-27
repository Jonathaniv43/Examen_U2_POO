using Azure;
using ExamenSegundaUnidad.Dtos.Common;
using ExamenSegundaUnidad.Dtos.New;
using ExamenSegundaUnidad.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenSegundaUnidad.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class ProspectsController : ControllerBase
    {
        private readonly IProspectsService _prospectService;

        public ProspectsController(IProspectsService loanService)
        {
            this._prospectService = loanService;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseDto<ProspectDto>>> Create(ProspectCreateDto dto)
        {
            var response = await _prospectService.CreateProspectAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
            });
        }



    }
}
