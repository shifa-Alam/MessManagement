using AutoMapper;
using MM.Core.Entities;
using MM.Core.Models;

namespace MessManagement.Web.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<MealInputModel, Meal>();
            CreateMap<MemberInputModel, Member>();
            CreateMap<BazarInputModel, Bazar>();

            CreateMap<Bazar, BazarViewModel>();
            CreateMap<Meal, MealViewModel>();
            CreateMap<Member, MemberViewModel>();
        }
    }
}
