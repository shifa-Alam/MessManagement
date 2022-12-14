using AutoMapper;
using MessManagement.Core.Helpers;
using MessManagement.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using MM.Core.Models.InputModel;
using MM.Core.Models.ViewModel;
using MM.Core.Services;
using X.PagedList;

namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;
        private readonly IBazarService _bazarService;
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;


        public MemberController(IMemberService memberService, IMealService mealService, IBazarService bazarService, IMapper mapper)
        {

            _memberService = memberService;
            _mealService = mealService;
            _bazarService = bazarService;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("SaveMember")]
        public IActionResult SaveMember(MemberInputModel memberIn)
        {
           
            var mappedData = _mapper.Map<Member>(memberIn);

            _memberService.Save(mappedData);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateMember")]
        public IActionResult UpdateMember(MemberInputModel memberIn)
        {
            
            var mappedData = _mapper.Map<Member>(memberIn);

            _memberService.Update(mappedData);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteMember")]
        public IActionResult DeleteMember(long id)
        {
            _memberService.DeleteById(id);

            return Ok();
        }



        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var member = _memberService.FindById(id);

            var mappedData = _mapper.Map<MemberViewModel>(member);
            return Ok(mappedData);

        }




        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers([FromQuery] MemberFilter filter)
        {
            var customPagedList = _memberService.GetFilterable(filter);

            var pagedList = _mapper.Map<IPagedList<Member>, ICustomPagedList<MemberViewModel>>((IPagedList<Member>)customPagedList);

            return Ok(pagedList);

        }

        [HttpGet]
        [Route("GetReport")]
        public IActionResult GetReport(string startDate, string endDate)
        {
            Report report = new Report();

            DateTime newStartDate = DateUtil.StartOfTheDay(DateTime.Parse(startDate));
            DateTime newEndDate = DateUtil.EndOfTheDay(DateTime.Parse(endDate));

            var members = _memberService.Get();


            IList<MemberReport> memberReports = new List<MemberReport>();

            foreach (var member in members)
            {
                MemberReport memberReport = new MemberReport();
                memberReport.MemberName = member.FirstName + " " + member.LastName;

                var memberwiseMeal = _mealService.GetByMemberIdAndDateRange(member.Id, newStartDate, newEndDate);
                var memberwiseExpense = _bazarService.GetByMemberIdAndDateRange(member.Id, newStartDate, newEndDate);

                memberReport.MealCount = memberwiseMeal.Sum(e => e.Quantity);
                memberReport.ExpenceAmount = memberwiseExpense.Sum(e => e.Amount);

                memberReports.Add(memberReport);


                report.TotalMeal += memberwiseMeal.Sum(e => e.Quantity);
                report.TotalExpence += memberwiseExpense.Sum(e => e.Amount);

            }
            if (report.TotalMeal > 0 && report.TotalExpence > 0)
                report.MealRate = (double)report.TotalExpence / report.TotalMeal;

            report.MemberReports = memberReports;
            foreach (var m in report.MemberReports)
            {
                m.TotalConsume = m.MealCount * report.MealRate;

                m.NetAmount = (double)(m.ExpenceAmount) - (m.MealCount * report.MealRate);
            }

            return Ok(report);

        }



        public override void Dispose()
        {
            _mealService?.Dispose();
            _memberService?.Dispose();
            _bazarService?.Dispose();
        }
    }

    public class Report
    {
        public double TotalMeal { get; set; } = 0;
        public decimal TotalExpence { get; set; } = 0;
        public double MealRate { get; set; } = 0;
        public IList<MemberReport>? MemberReports { get; set; }
    }

    public class MemberReport
    {
        public string? MemberName { get; set; }
        public double MealCount { get; set; } = 0;
        public decimal ExpenceAmount { get; set; } = 0;
        public double TotalConsume { get; set; } = 0;

        public double NetAmount { get; set; } = 0;

    }
}