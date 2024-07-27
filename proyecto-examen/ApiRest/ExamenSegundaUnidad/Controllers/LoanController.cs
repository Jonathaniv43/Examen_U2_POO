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
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            this._loanService = loanService;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseDto<LoanDto>>> Create(LoanCreateDto dto)
        {
            var response = await _loanService.CreateLoanAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
            });
        }



    }
}
