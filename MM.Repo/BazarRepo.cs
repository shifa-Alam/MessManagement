using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MM.Repo
{
    public class BazarRepo : GenericRepository<Bazar>, IBazarRepo
    {
        public BazarRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Bazar> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = context.Bazars.Where(e => e.MemberId == memberId && e.BazarDate >= startDate && e.BazarDate <= endDate).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Bazar> GetFilterable(BazarFilter filter)
        {
            //var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);
            IQueryable<Bazar> queryResult = context.Bazars?.Include(e => e.Member);

            queryResult = queryResult.Where(e => e.BazarDate >= filter.StartDate
                    && e.BazarDate <= filter.EndDate
                    && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.BazarDate);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;
        }
    }
}
