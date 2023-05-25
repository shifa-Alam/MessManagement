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
    public class MemberRepo : GenericRepository<Member>, IMemberRepo
    {
        public MemberRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Member> GetFilterable(MemberFilter filter)
        {
            //var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);

            IQueryable<Member> queryResult = context.Members;

            queryResult = queryResult.Where(e =>
                                     (!string.IsNullOrEmpty(filter.MemberName) ? (e.FirstName.Contains(filter.MemberName) || e.LastName.Contains(filter.MemberName)) : true)
                                    && (!string.IsNullOrEmpty(filter.MobileNumber) ? (e.MobileNumber.Contains(filter.MobileNumber)) : true) && e.Active==true);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;
        }
    }
}
