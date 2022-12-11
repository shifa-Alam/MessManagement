using AutoMapper;
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

    public class BazarController : BaseController
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
            var bazar = _mapper.Map<Bazar>(bazarIn);
            _bazarService.Save(bazar);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateBazar")]
        public IActionResult UpdateBazar(BazarInputModel bazarIn)
        {
           
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
        public IActionResult GetBazars([FromQuery] BazarFilter filter)
        {

            var customPagedList = _bazarService.Get(filter);

            var pagedList = _mapper.Map<IPagedList<Bazar>, ICustomPagedList<BazarViewModel>>((IPagedList<Bazar>)customPagedList);

            return Ok(pagedList);

        }


        [HttpGet]
        [Route("GetMembers")]
        public IActionResult GetMembers()
        {

            var members = _memberService.Get();
            var mamppedModel = _mapper.Map<List<MemberViewModel>>(members);
            return Ok(mamppedModel);
           

        }

       

        public override void Dispose()
        {
            _bazarService?.Dispose();
            _memberService?.Dispose();
        }
    }
}