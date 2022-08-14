using Microsoft.AspNetCore.Mvc;

namespace MessManagement.Web.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

    

        [HttpGet]
        //[Route("GetMembers")]
        public IEnumerable<Member> GetMembers()
        {
            return Enumerable.Range(1, 10).Select(index => new Member
            {
                FirstName = "FirstName " + index,
                LastName = "LastName " + index,
                MobileNumber = "MobileNumber " + index,
                EmergencyContact = "Emergency Contact " + index
            })
            .ToArray();
        }
    }
}