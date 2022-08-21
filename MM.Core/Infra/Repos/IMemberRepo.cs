using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IMemberRepo
    {
        public Member Save(Member member);
        public Member Update(Member m);
        public void Delete(long id);
        public Member FindById(long id);
        public IEnumerable<Member> Get();
    }
}
