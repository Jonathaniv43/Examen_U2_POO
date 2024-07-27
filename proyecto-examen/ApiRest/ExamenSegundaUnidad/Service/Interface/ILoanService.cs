using ExamenSegundaUnidad.Dtos.Common;
using ExamenSegundaUnidad.Dtos.New;

namespace ExamenSegundaUnidad.Service.Interface
{
    public interface ILoanService
    {
        Task<ResponseDto<LoanDto>> CreateLoanAsync(LoanCreateDto dto);

    }
}
