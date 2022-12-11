using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IBazarRepo : IGenericRepository<Bazar>
    {
       
        IEnumerable<Bazar> GetByMemberIdAndDateRange(long id, DateTime startDate, DateTime endDate);
        IEnumerable<Bazar> GetFilterable(BazarFilter filter);
    }
}
