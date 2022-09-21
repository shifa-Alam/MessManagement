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

    public class BazarController : Controller
    {
        List<BazarInputModel> bazars = new List<BazarInputModel>();

        private readonly ILogger<BazarController> _logger;
        private readonly IBazarService _bazarService;
        private readonly IMemberService _memberService;



        public BazarController(ILogger<BazarController> logger, IBazarService bazarService, IMemberService memberService)
        {
            _logger = logger;
            _bazarService = bazarService;
            _memberService = memberService;
        }



        [HttpPost]
        [Route("SaveBazar")]
        public IActionResult SaveBazar(BazarInputModel bazarIn)
        {
            Bazar m = new Bazar();
            m.MemberId = bazarIn.MemberId;
            m.Amount = bazarIn.Amount;
            m.BazarDate = bazarIn.BazarDate;


            var bazar = _bazarService.Save(m);
            return Ok(bazar);
        }

        [HttpPost]
        [Route("UpdateBazar")]
        public IActionResult UpdateBazar(BazarInputModel bazarIn)
        {
            Bazar m = new Bazar();
            m.Id = bazarIn.Id;
            m.MemberId = bazarIn.MemberId;
            m.Amount = bazarIn.Amount;
            m.BazarDate = bazarIn.BazarDate;



            var bazar = _bazarService.Update(m);
            return Ok(bazar);
        }

        [HttpDelete]
        [Route("DeleteBazar")]
        public IActionResult DeleteBazar(long id)
        {
            _bazarService.DeleteById(id);

            return Ok();
        }

        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var bazars = _bazarService.FindById(id);
            return Ok(bazars);

        }

        [HttpGet]
        [Route("GetBazars")]
        public IActionResult GetBazars()
        {

            var bazars = _bazarService.Get();
            var bazarViewModels= new List<BazarViewModel>();
            foreach (var bazar in bazars)
            {
                BazarViewModel vm = new BazarViewModel();
                vm.Id = bazar.Id;
                vm.MemberId = bazar.MemberId;
                vm.Amount = bazar.Amount;
                vm.BazarDate = bazar.BazarDate;
                vm.CreatedDate= bazar.CreatedDate;
                vm.ModifiedDate= bazar.ModifiedDate;
                vm.Active=bazar.Active;
                vm.MemberFirstName = bazar.Member.FirstName;
                vm.MemberLastName = bazar.Member.LastName;
                bazarViewModels.Add(vm);

            }
            return Ok(bazarViewModels);

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