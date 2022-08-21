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

    public class MemberController : Controller
    {
        List<MemberInputModel> members = new List<MemberInputModel>();

        private readonly ILogger<MemberController> _logger;
        private readonly IMemberService _memberService;



        public MemberController(ILogger<MemberController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }



        [HttpPost]
        [Route("SaveMember")]
        public IActionResult SaveMember(MemberInputModel memberIn)
        {
            Member m = new Member();
            m.FirstName = memberIn.FirstName;
            m.LastName = memberIn.LastName;
            m.MobileNumber = memberIn.MobileNumber;


            var member = _memberService.Save(m);
            return Ok(member);
        }
        [HttpPost]
        [Route("UpdateMember")]
        public IActionResult UpdateMember(MemberInputModel memberIn)
        {
            Member m = new Member();
            m.FirstName = memberIn.FirstName;
            m.LastName = memberIn.LastName;
            m.MobileNumber = memberIn.MobileNumber;


            var member = _memberService.Update(m);
            return Ok(member);
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
        public IActionResult FindById( long id)
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
    }
}