using Microsoft.AspNetCore.Mvc;
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
        List<MealInputModel> meals = new List<MealInputModel>();

        private readonly ILogger<MealController> _logger;
        private readonly IMealService _mealService;
        private readonly IMemberService _memberService;



        public MealController(ILogger<MealController> logger, IMealService mealService, IMemberService memberService)
        {
            _logger = logger;
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


            var meal = _mealService.Save(m);
            return Ok(meal);
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



            var meal = _mealService.Update(m);
            return Ok(meal);
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
    }
}