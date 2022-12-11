using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public  interface IMemberService : IBaseService
    {
        public void Save(Member entity);
        public void Update(Member entity);
        public void DeleteById(long id);
        public Member SoftDelete(Member entity);
        public Member FindById(long id);
        public IEnumerable<Member> Get();
        public IEnumerable<Member> GetFilterable(MemberFilter filter);
    }
}
