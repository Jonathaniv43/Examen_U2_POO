using AutoMapper;

namespace ExamenSegundaUnidad.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForEntity();
        }

        private void MapsForEntity()
        {
            //CreateMap<OrderEntity, OrderDto>(); // mapea los valores que coinciden entre donde se envia a donde se recibe
            //CreateMap<OrderCreateDto, OrderEntity>();
            //CreateMap<OrderEditDto, OrderEntity>();
        }

    }
}
