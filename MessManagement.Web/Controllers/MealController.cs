using AutoMapper;
using Castle.Core.Resource;
using MessManagement.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using MM.bll.Services;
using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using MM.Core.Models.InputModel;
using MM.Core.Models.ViewModel;
using MM.Core.Services;
using System.Diagnostics.Metrics;
using System.Reflection;
using X.PagedList;

namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MealController : BaseController
    {

        private readonly IMealService _mealService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;



        public MealController(IMealService mealService, IMemberService memberService, IMapper mapper)
        {

            _mealService = mealService;
            _memberService = memberService;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("SaveMeal")]
        public IActionResult SaveMeal(MealInputModel mealIn)
        {
            var mappedModel = _mapper.Map<Meal>(mealIn);

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
        public IActionResult GetMeals([FromQuery] MealFilter filter)
        {

            var customPagedList = _mealService.GetWithFilterReplica(filter);
            //var mappedModel = _mapper.Map<List<MealViewModel>>(meals.Data);

            //var response = new PagedResponse<List<MealViewModel>>(_mapper.Map<List<MealViewModel>>(meals.Data), meals.PageNumber, meals.PageSize);
            //response.TotalRecords = meals.TotalRecords; 
            
            var response =(IPagedList<Meal>)customPagedList;
            //var r = new PagedResponse<List<MealViewModel>>(_mapper.Map<List<MealViewModel>>(response.Subset), response.PageNumber, response.PageSize);
            var r = _mapper.Map< IPagedList < Meal > ,ICustomPagedList < MealViewModel >> (response);
            return Ok(response);

        }


        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            var mappedModel = _mapper.Map<List<MemberViewModel>>(members);
            return Ok(mappedModel);

        }



        public override void Dispose()
        {
            _mealService?.Dispose();
            _memberService?.Dispose();

        }
    }
}