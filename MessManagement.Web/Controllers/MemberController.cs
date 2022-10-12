using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MM.Core.Entities;
using MM.Core.Models;
using MM.Core.Services;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MemberController : Controller
    {

       
        private readonly IMemberService _memberService;
        private readonly IBazarService _bazarService;
        private readonly IMealService _mealService;


        public MemberController( IMemberService memberService, IMealService mealService, IBazarService bazarService)
        {
          
            _memberService = memberService;
            _mealService = mealService;
            _bazarService = bazarService;
        }



        [HttpPost]
        [Route("SaveMember")]
        public IActionResult SaveMember(MemberInputModel memberIn)
        {
            Member m = new Member();
            m.FirstName = memberIn.FirstName;
            m.LastName = memberIn.LastName;
            m.MobileNumber = memberIn.MobileNumber;
            m.HomeDistrict = memberIn.HomeDistrict;

            _memberService.Save(m);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateMember")]
        public IActionResult UpdateMember(MemberInputModel memberIn)
        {
            Member m = new Member();
            m.Id = memberIn.Id;
            m.FirstName = memberIn.FirstName;
            m.LastName = memberIn.LastName;
            m.MobileNumber = memberIn.MobileNumber;
            m.HomeDistrict = memberIn.HomeDistrict;
            m.EmergencyContact = memberIn.EmergencyContact;
            
            _memberService.Update(m);
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

            var members = _memberService.FindById(id);
            return Ok(members);

        }




        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            return Ok(members);

        }

        [HttpGet]
        [Route("GetReport")]
        public IActionResult GetReport( string startDate, string endDate)
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

            report.MealRate = (double)report.TotalExpence / report.TotalMeal;

            report.MemberReports = memberReports;
            foreach (var m in report.MemberReports)
            {
                m.TotalConsume = m.MealCount * report.MealRate;

                m.NetAmount =   (double)(m.ExpenceAmount)- (m.MealCount * report.MealRate);
            }

            return Ok(report);

        }

    }

    public class Report
    {
        public double TotalMeal { get; set; }
        public decimal TotalExpence { get; set; }
        public double MealRate { get; set; }
        public IList<MemberReport> MemberReports { get; set; }
    }

    public class MemberReport
    {
        public string MemberName { get; set; }
        public double MealCount { get; set; }
        public decimal ExpenceAmount { get; set; }
        public double TotalConsume { get; set; }

        public double NetAmount { get; set; }

    }
}