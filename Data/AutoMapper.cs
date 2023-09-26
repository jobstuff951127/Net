using AutoMapper;
using NTT_Data.Data.DTOS;
using NTT_Data.Models;

namespace NTT_Data.Data
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ConceptDto, Concept>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<SaleDto, Sale>();
            CreateMap<ProductDto, Product>();
        }
    }
}
