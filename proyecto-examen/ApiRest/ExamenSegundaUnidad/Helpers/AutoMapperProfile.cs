using AutoMapper;
using ExamenSegundaUnidad.Database.Entity;
using ExamenSegundaUnidad.Dtos.New;

namespace ExamenSegundaUnidad.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForProspects();
        }

        private void MapsForProspects()
        {
            CreateMap<ProspectsEntity, ProspectDto>(); // mapea los valores que coinciden entre donde se envia a donde se recibe
            CreateMap<ProspectCreateDto, ProspectsEntity>();
            CreateMap<ProspectEditDto, ProspectEntity>();
        }

    }
}
