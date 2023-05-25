using MessManagement.Core.Helpers;
using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IFundRepo : IGenericRepository<Fund>
    {
        IEnumerable<Fund> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
        IEnumerable<Fund> GetFilterable(FundFilter filter);
    }
}