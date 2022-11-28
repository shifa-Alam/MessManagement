using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MM.bll.Services;
using MM.Core.Entities;
using MM.Core.Models;
using MM.Core.Services;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MealController : Controller
    {
       
        private readonly IMealService _mealService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;



        public MealController( IMealService mealService, IMemberService memberService,IMapper mapper)
        {

            _mealService = mealService;
            _memberService = memberService;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("SaveMeal")]
        public IActionResult SaveMeal(MealInputModel mealIn)
        {
            var mappedModel= _mapper.Map<Meal>(mealIn);

             _mealService.Save(mappedModel);
            return Ok();
        }
        [HttpPost]
        [Route("SaveMealRange")]
        public IActionResult SaveMealRange(List<MealInputModel> mealIns)
        {
            //List<Meal> meals= new List<Meal>();
            //foreach (var item in mealIns)
            //{
            //    Meal m = new Meal();
            //    m.MemberId = item.MemberId;
            //    m.Quantity = item.Quantity;
            //    m.MealDate = item.MealDate;
            //    meals.Add(m);
            //}
            var mappedModel = _mapper.Map<List<Meal>>(mealIns);

            _mealService.SaveRange(mappedModel);

            return Ok();
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public IActionResult UpdateMeal(MealInputModel mealIn)
        {
            //Meal m = new Meal();
            //m.Id = mealIn.Id;
            //m.MemberId = mealIn.MemberId;
            //m.Quantity = mealIn.Quantity;
            //m.MealDate = mealIn.MealDate;

            var mappedModel = _mapper.Map<Meal>(mealIn);


            _mealService.Update(mappedModel);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMeal")]
        public IActionResult DeleteMeal(long id)
        {
            _mealService.DeleteById(id);

            return Ok();
        }

        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var meal = _mealService.FindById(id);
            var mappedModel = _mapper.Map<List<MealViewModel>>(meal);
            return Ok(mappedModel);

        }

        [HttpGet]
        [Route("GetMeals")]
        public IActionResult GetMeals()
        {

            var meals = _mealService.Get();
            //var mealViewModels= new List<MealViewModel>();
            //foreach (var meal in meals)
            //{
            //    MealViewModel vm = new MealViewModel();
            //    vm.Id = meal.Id;
            //    vm.MemberId = meal.MemberId;
            //    vm.Quantity = meal.Quantity;
            //    vm.MealDate = meal.MealDate;
            //    vm.CreatedDate= meal.CreatedDate;
            //    vm.ModifiedDate= meal.ModifiedDate;
            //    vm.Active=meal.Active;
            //    vm.MemberFirstName = meal.Member.FirstName;
            //    vm.MemberLastName = meal.Member.LastName;
            //    mealViewModels.Add(vm);

            //}
            var mappedModel = _mapper.Map<List<MealViewModel>>(meals);
            return Ok(mappedModel);

        }


        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            var mappedModel = _mapper.Map<List<MemberViewModel>>(members);
            return Ok(mappedModel);

        }

        protected override void Dispose(bool disposing)
        {
           
            _mealService?.Dispose();
            _memberService?.Dispose();
        }
    }
}