using AutoMapper;
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

        private readonly IBazarService _bazarService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;


        public BazarController(IBazarService bazarService, IMemberService memberService, IMapper mapper)
        {
            _bazarService = bazarService;
            _memberService = memberService;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("SaveBazar")]
        public IActionResult SaveBazar(BazarInputModel bazarIn)
        {
            //Bazar m = new Bazar();
            //m.MemberId = bazarIn.MemberId;
            //m.Amount = bazarIn.Amount;
            //m.BazarDate = bazarIn.BazarDate;
            var bazar = _mapper.Map<Bazar>(bazarIn);

            _bazarService.Save(bazar);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateBazar")]
        public IActionResult UpdateBazar(BazarInputModel bazarIn)
        {
            //Bazar m = new Bazar();
            //m.Id = bazarIn.Id;
            //m.MemberId = bazarIn.MemberId;
            //m.Amount = bazarIn.Amount;
            //m.BazarDate = bazarIn.BazarDate;

            var bazar = _mapper.Map<Bazar>(bazarIn);

            _bazarService.Update(bazar);
            return Ok();
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

            var existing = _bazarService.FindById(id);
            var bazar = _mapper.Map<BazarViewModel>(existing);
            return Ok(bazar);

        }

        [HttpGet]
        [Route("GetBazars")]
        public IActionResult GetBazars()
        {

            var bazars = _bazarService.Get();
            //var bazarViewModels = new List<BazarViewModel>();
            //foreach (var bazar in bazars)
            //{
            //    BazarViewModel vm = new BazarViewModel();
            //    vm.Id = bazar.Id;
            //    vm.MemberId = bazar.MemberId;
            //    vm.Amount = bazar.Amount;
            //    vm.BazarDate = bazar.BazarDate;
            //    vm.CreatedDate = bazar.CreatedDate;
            //    vm.ModifiedDate = bazar.ModifiedDate;
            //    vm.Active = bazar.Active;
            //    vm.MemberFirstName = bazar.Member.FirstName;
            //    vm.MemberLastName = bazar.Member.LastName;
            //    bazarViewModels.Add(vm);

            //}
            var mamppedModel = _mapper.Map<List<BazarViewModel>>(bazars);
            return Ok(mamppedModel);

        }


        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            var mamppedModel = _mapper.Map<List<MemberViewModel>>(members);
            return Ok(mamppedModel);
           

        }

        protected override void Dispose(bool disposing)
        {
            _bazarService?.Dispose();
            _memberService?.Dispose();
        }

    }
}