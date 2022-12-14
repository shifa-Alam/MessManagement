using AutoMapper;
using MM.Core.Entities;
using MM.Core.Models.InputModel;
using MM.Core.Models.ViewModel;
using X.PagedList;

namespace MessManagement.Web.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<MealInputModel, Meal>();
            CreateMap<MemberInputModel, Member>();
            CreateMap<BazarInputModel, Bazar>();

            CreateMap<Bazar, BazarViewModel>()
                .ForMember(dest => dest.MemberFirstName, m => m.MapFrom(src => src.Member.FirstName))
                .ForMember(dest => dest.MemberLastName, m => m.MapFrom(src => src.Member.LastName));
            CreateMap<Meal, MealViewModel>()
                 .ForMember(dest => dest.MemberFirstName, m => m.MapFrom(src => src.Member.FirstName))
                .ForMember(dest => dest.MemberLastName, m => m.MapFrom(src => src.Member.LastName));
            CreateMap<Member, MemberViewModel>();

            CreateMap(typeof(PagedList<>), typeof(CustomPagedList<>)).ReverseMap().PreserveReferences();
            CreateMap(typeof(IPagedList<>), typeof(ICustomPagedList<>)).PreserveReferences().ConvertUsing(typeof(PagedListConverter<,>));
           
            
        }
    }
}
