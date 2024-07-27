using ExamenSegundaUnidad.Dtos.Common;
using ExamenSegundaUnidad.Dtos.New;

namespace ExamenSegundaUnidad.Service.Interface
{
    public interface IProspectsService
    {
        Task<ResponseDto<ProspectDto>> CreateProspectAsync(ProspectCreateDto dto);

    }
}
