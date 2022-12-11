using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IMemberRepo : IGenericRepository<Member>
    {

        IEnumerable<Member> GetFilterable(MemberFilter filter);
    }
}
