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

    public class FundController : BaseController
    {

        private readonly IFundService _fundService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;



        public FundController(IFundService fundService, IMemberService memberService, IMapper mapper)
        {

            _fundService = fundService;
            _memberService = memberService;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("SaveFund")]
        public IActionResult SaveFund(FundInputModel fundIn)
        {
            var mappedModel = _mapper.Map<Fund>(fundIn);

            _fundService.Save(mappedModel);
            return Ok();
        }
        [HttpPost]
        [Route("SaveFundRange")]
        public IActionResult SaveFundRange(List<FundInputModel> fundIns)
        {
            //List<Fund> funds= new List<Fund>();
            //foreach (var item in fundIns)
            //{
            //    Fund m = new Fund();
            //    m.MemberId = item.MemberId;
            //    m.Quantity = item.Quantity;
            //    m.FundDate = item.FundDate;
            //    funds.Add(m);
            //}
            var mappedModel = _mapper.Map<List<Fund>>(fundIns);

            _fundService.SaveRange(mappedModel);

            return Ok();
        }

        [HttpPost]
        [Route("UpdateFund")]
        public IActionResult UpdateFund(FundInputModel fundIn)
        {
            //Fund m = new Fund();
            //m.Id = fundIn.Id;
            //m.MemberId = fundIn.MemberId;
            //m.Quantity = fundIn.Quantity;
            //m.FundDate = fundIn.FundDate;

            var mappedModel = _mapper.Map<Fund>(fundIn);


            _fundService.Update(mappedModel);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteFund")]
        public IActionResult DeleteFund(long id)
        {
            _fundService.DeleteById(id);

            return Ok();
        }

        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var fund = _fundService.FindById(id);
            var mappedModel = _mapper.Map<List<FundViewModel>>(fund);
            return Ok(mappedModel);

        }

        [HttpGet]
        [Route("GetFunds")]
        public IActionResult GetFunds([FromQuery] FundFilter filter)
        {
            filter.StartDate = null;
            filter.EndDate = null;
            var customPagedList = _fundService.Get(filter);


         
            var pagedList = _mapper.Map<IPagedList<Fund>, ICustomPagedList<FundViewModel>>((IPagedList<Fund>)customPagedList);
           
            return Ok(pagedList);

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
            _fundService?.Dispose();
            _memberService?.Dispose();

        }
    }
}