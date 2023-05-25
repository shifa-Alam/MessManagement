using MessManagement.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Models.FilterModel;
using MM.Core.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MM.Repo
{
    public class FundRepo : GenericRepository<Fund>, IFundRepo
    {
        public FundRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Fund> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = context.Funds.Where(e => e.MemberId == memberId && (e.FundDate >= startDate && e.FundDate <= endDate)).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<Fund> GetFilterable(FundFilter filter)
        {
            //var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);
            IQueryable<Fund> queryResult = context.Funds?.Include(e => e.Member);

            if (filter.StartDate != null && filter.EndDate != null)
            {
                queryResult = queryResult.Where(e => e.FundDate >= filter.StartDate
                && e.FundDate <= filter.EndDate
                && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.FundDate);
            }
            else
            {
                queryResult = queryResult.Where(e =>(!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.FundDate);
            }


            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;
        }

    }



}
