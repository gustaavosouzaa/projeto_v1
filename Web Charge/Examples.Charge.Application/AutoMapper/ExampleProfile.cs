using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<PersonPhone, PersonPhoneDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.PhoneNumberTypeName, opt => opt.MapFrom(src => src.PhoneNumberType.Name))
               .ReverseMap();

            CreateMap<PersonPhone, RemovePersonPhoneRequest>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
              .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
              .ReverseMap();

            CreateMap<Person, PersonPhonesResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ReverseMap();

            CreateMap<Person, PersonDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ReverseMap();

            CreateMap<PersonPhone, PersonPhoneRequest>()
               .ReverseMap();
        }
    }
}
