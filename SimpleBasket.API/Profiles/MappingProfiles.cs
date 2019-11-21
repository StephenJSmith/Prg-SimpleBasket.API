using AutoMapper;

namespace SimpleBasket.API.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Entities.Product, Dtos.ProductDto>();
            CreateMap<Dtos.OrderItemForSubmitDto, Entities.OrderItem>();
        }
    }
}
