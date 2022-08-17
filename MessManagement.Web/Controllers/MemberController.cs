using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MemberController : Controller
    {
        List<Member> members = new List<Member>();

        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
            for (int index = 1; index < 100; index++)
            {
                Member member = new Member()
                {

                    Id = index,
                    FirstName = "RAKIB ",
                    LastName = "Hasan " + index,
                    MobileNumber = "0192862387" + index,
                    EmergencyContact = "Emergency Contact " + index,
                    HomeDistrict = "Dhaka-" + index,
                    Active = true

                };
                members.Add(member);
            }
        }



        [HttpGet]
        [Route("GetMembers")]
        public IEnumerable<Member> GetMembers()
        {
            
            return members;
        }
        [HttpPost]
        [Route("SaveMember")]
        public IActionResult SaveMember(Member member)
        {
            members.Add(member);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateMember")]
        public IActionResult UpdateMember(Member member)
        {
            members.Add(member);
            return Ok(member);
        }
        [HttpDelete]
        [Route("DeleteMember")]
        public IActionResult DeleteMember(long id)
        {
            var member=members.Find(x => x.Id == id);
             members.Remove(member);
            return Ok(member);
        }
    }
}