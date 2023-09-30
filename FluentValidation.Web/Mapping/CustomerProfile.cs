using AutoMapper;
using FluentValidation.Web.Dto;
using FluentValidation.Web.Models;

namespace FluentValidation.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Title, member => member.MapFrom(source => source.Product.Title))
                .ForMember(dest => dest.Price, member => member.MapFrom(source => source.Product.Price))
                .ReverseMap(); //.ReverseMap() tam tersinin de kullanılmasını sağlıyor

            //IncludeMembers kullanmak için bunu da eklemeliyiz
            //CreateMap<CreditCard, CustomerDto>();

            //Dto'daki alanları dış dünyaya örneğin türkçe açmak istersek bu şekilde yapıyoruz
            //CreateMap<Customer, CustomerDto>()
            //    .IncludeMembers(x=>x.CreditCard) //Aynı isimlendirme için tek bir kullanım
            //    .ForMember(x => x.Isim, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(x => x.Yas, opt => opt.MapFrom(x => x.Age))
            //    .ForMember(x => x.Eposta, opt => opt.MapFrom(x => x.Email))
            //    .ForMember(x => x.NameAge, opt => opt.MapFrom(x => x.NameAge())); 
            //modelde get söz dizimi olmadığı için manuel olarak eşledik
        }
    }
}
