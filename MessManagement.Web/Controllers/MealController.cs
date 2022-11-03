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



        public MealController( IMealService mealService, IMemberService memberService)
        {
           
            _mealService = mealService;
            _memberService = memberService;
        }



        [HttpPost]
        [Route("SaveMeal")]
        public IActionResult SaveMeal(MealInputModel mealIn)
        {
            Meal m = new Meal();
            m.MemberId = mealIn.MemberId;
            m.Quantity = mealIn.Quantity;
            m.MealDate = mealIn.MealDate;


             _mealService.Save(m);
            return Ok();
        }
        [HttpPost]
        [Route("SaveMealRange")]
        public IActionResult SaveMealRange(List<MealInputModel> mealIns)
        {
            List<Meal> meals= new List<Meal>();
            foreach (var item in mealIns)
            {
                Meal m = new Meal();
                m.MemberId = item.MemberId;
                m.Quantity = item.Quantity;
                m.MealDate = item.MealDate;
                meals.Add(m);
            }
          
            _mealService.SaveRange(meals);

            return Ok();
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public IActionResult UpdateMeal(MealInputModel mealIn)
        {
            Meal m = new Meal();
            m.Id = mealIn.Id;
            m.MemberId = mealIn.MemberId;
            m.Quantity = mealIn.Quantity;
            m.MealDate = mealIn.MealDate;



            _mealService.Update(m);
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

            var meals = _mealService.FindById(id);
            return Ok(meals);

        }

        [HttpGet]
        [Route("GetMeals")]
        public IActionResult GetMeals()
        {

            var meals = _mealService.Get();
            var mealViewModels= new List<MealViewModel>();
            foreach (var meal in meals)
            {
                MealViewModel vm = new MealViewModel();
                vm.Id = meal.Id;
                vm.MemberId = meal.MemberId;
                vm.Quantity = meal.Quantity;
                vm.MealDate = meal.MealDate;
                vm.CreatedDate= meal.CreatedDate;
                vm.ModifiedDate= meal.ModifiedDate;
                vm.Active=meal.Active;
                vm.MemberFirstName = meal.Member.FirstName;
                vm.MemberLastName = meal.Member.LastName;
                mealViewModels.Add(vm);

            }
            return Ok(mealViewModels);

        }


        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            return Ok(members);

        }

        protected override void Dispose(bool disposing)
        {
           
            _mealService?.Dispose();
            _memberService?.Dispose();
        }
    }
}