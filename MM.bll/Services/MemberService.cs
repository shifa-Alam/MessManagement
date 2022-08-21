using MM.Core.Entities;
using MM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.bll.Services
{
    public class MemberService : IMemberService
    {
       

        public Member Save(Member member)
        {
          return member;
        }

     

        public Member Update(Member member)
        {
            return member;
        }
        public void DeleteById(long id)
        {
            
        }
        public Member SoftDelete(Member member)
        {
            return member;
        }

        public Member FindById(long id)
        {
            return null;
        }

        public IEnumerable<Member> Get()
        {
            List<Member> list = new List<Member>();
            for (int i = 1; i < 20; i++)
            {
                var member = new Member()
                {
                    Id = i,
                    FirstName = "Rakib " + i,
                    LastName = "Hasan " + i,
                    MobileNumber="0192863387"+i,
                    HomeDistrict="Dhaka "+i


                };
                list.Add(member);
            }
            return list;
        }
    }
}
