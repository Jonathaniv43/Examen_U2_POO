using AutoMapper;
using ExamenSegundaUnidad.Database.Context;
using ExamenSegundaUnidad.Database.Entity;
using ExamenSegundaUnidad.Dtos.Amortization;
using ExamenSegundaUnidad.Dtos.Common;
using ExamenSegundaUnidad.Dtos.New;
using ExamenSegundaUnidad.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExamenSegundaUnidad.Service
{
    public class LoanService : ILoanService
    {
        private readonly ProjectServiceDbContext _context;
        private readonly ILogger<LoanService> _logger;
        private readonly IMapper _mapper;
      

        public LoanService(ProjectServiceDbContext context, ILogger<LoanService> logger, IMapper mapper)
        {
            this._context = context;
            this._logger = logger;
            this._mapper = mapper;
        }

        //public async Task<ResponseDto<LoanDto>> CreateLoanAsync(LoanCreateDto dto)
        //{

        //    var loanEntity = _mapper.Map<LoanEntity>(dto);
        //    loanEntity.LoanId = new Guid();

        //    _context.Loans.Add(loanEntity);

        //    await _context.SaveChangesAsync();


        //    var loanDto = _mapper.Map<LoanDto>(loanEntity);

        //    var amortizationEntity = _mapper.Map<AmortizationDto>(loanDto.Id);



        //}

    }
}
