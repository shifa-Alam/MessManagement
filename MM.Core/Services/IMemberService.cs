using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public  interface IMemberService
    {
        public Member Save(Member member);
        public Member Update(Member member);
        public void DeleteById(long id);
        public Member SoftDelete(Member member);
        public Member FindById(long id);
        public IEnumerable<Member> Get();
    }
}
