using AutoMapper;
using FluentValidation.Web.Dto;
using FluentValidation.Web.Models;

namespace FluentValidation.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //CreateMap<Customer, CustomerDto>().ReverseMap(); //.ReverseMap() tam tersinin de kullanılmasını sağlıyor

            //Dto'daki alanları dış dünyaya örneğin türkçe açmak istersek bu şekilde yapıyoruz
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.Isim, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(x => x.Eposta, opt => opt.MapFrom(x => x.Email));
        }
    }
}
