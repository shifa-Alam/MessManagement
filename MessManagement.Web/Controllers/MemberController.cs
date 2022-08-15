using Microsoft.AspNetCore.Mvc;

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
            for (int index = 1; index < 10; index++)
            {
                Member member = new Member()
                {

                    Id = index,
                    FirstName = "FirstName " + index,
                    LastName = "LastName " + index,
                    MobileNumber = "MobileNumber " + index,
                    EmergencyContact = "Emergency Contact " + index,
                    HomeDistrict = "HomeDistrict " + index,
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
        public IEnumerable<Member> SaveMember(Member member)
        {
            members.Add(member);
            return members;
        }
    }
}