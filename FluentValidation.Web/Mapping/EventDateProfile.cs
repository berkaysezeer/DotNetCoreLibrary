using AutoMapper;
using FluentValidation.Web.Dto;
using FluentValidation.Web.Models;

namespace FluentValidation.Web.Mapping
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            //örneği kullanıcıdan dto ile veri alıyorsak EvenDateDto kaynak (source), model ise varış noktası (destination) olur
            // CreateMap<EventDateDto, EventDate>()
            //.ForMember(x => x.Date.Month, opt => opt.MapFrom(x => x.Month))
            //.ForMember(x => x.Date.Day, opt => opt.MapFrom(x => x.Day))
            //.ForMember(x => x.Date.Year, opt => opt.MapFrom(x => x.Year));

            CreateMap<EventDateDto, EventDate>()
           .ForMember(x => x.Date, opt => opt.MapFrom(x => new DateTime(x.Year, x.Month, x.Day)));

            //reversmap çalışmaycağı için tersini de tanımlıyoruz
            CreateMap<EventDate, EventDateDto>()
           .ForMember(x => x.Month, opt => opt.MapFrom(x => x.Date.Month))
           .ForMember(x => x.Day, opt => opt.MapFrom(x => x.Date.Day))
           .ForMember(x => x.Year, opt => opt.MapFrom(x => x.Date.Year));
        }
    }
}
