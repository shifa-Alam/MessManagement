using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public  interface IMemberService : IDisposable
    {
        public void Save(Member entity);
        public void Update(Member entity);
        public void DeleteById(long id);
        public Member SoftDelete(Member entity);
        public Member FindById(long id);
        public IEnumerable<Member> Get();
    }
}
