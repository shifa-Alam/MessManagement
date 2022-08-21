using MM.Core.Entities;
using MM.Core.Infra.Repos;
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
        private IMemberRepo _memberRepo;
        public MemberService(IMemberRepo memberRepo)
        {
            _memberRepo = memberRepo;
        }
        public Member Save(Member member)
        {
            member.Active = true;
            member.CreatedDate=DateTime.Now;
          return _memberRepo.Save(member);
        }

        public Member Update(Member member)
        {
            return _memberRepo.Update(member);
        }
        public void DeleteById(long id)
        {
            _memberRepo.Delete(id);
        }
        public Member SoftDelete(Member member)
        {
            return member;
        }

        public Member FindById(long id)
        {
            return _memberRepo.FindById(id);
        }

        public IEnumerable<Member> Get()
        {          
            return _memberRepo.Get();
        }
    }
}
