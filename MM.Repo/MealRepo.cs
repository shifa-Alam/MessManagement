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
    public class MealRepo : GenericRepository<Meal>, IMealRepo
    {
        public MealRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = context.Meals.Where(e => e.MemberId == memberId && (e.MealDate >= startDate && e.MealDate <= endDate)).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<Meal> GetFilterable(MealFilter filter)
        {
            var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);
            IQueryable<Meal> queryResult = context.Meals?.Include(e => e.Member);
            queryResult = queryResult.Where(e => e.MealDate >= filter.StartDate
                    && e.MealDate <= filter.EndDate
                    && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.MealDate);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;
        }
        
    }



}
