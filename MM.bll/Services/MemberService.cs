using MessManagement.Core.Helpers;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Models.FilterModel;
using MM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.bll.Services
{
    public class MemberService : BaseService, IMemberService
    {
        private IUnitOfWork _repo;
        public MemberService(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public void Save(Member member)
        {
            member.Active = true;
            member.CreatedDate = DateTime.Now;

            _repo.MemberR.Add(member);
            _repo.Save();
        }

        public void Update(Member member)
        {
            var existingEntity = _repo.MemberR.GetById(member.Id);

            if (existingEntity != null)
            {
                existingEntity.FirstName = member.FirstName;
                existingEntity.LastName = member.LastName;
                existingEntity.MobileNumber = member.MobileNumber;
                existingEntity.EmergencyContact = member.EmergencyContact;
                existingEntity.HomeDistrict = member.HomeDistrict;
                existingEntity.ModifiedDate = DateTime.Now;

                _repo.MemberR.Update(existingEntity);
                _repo.Save();
            }


        }
        public void DeleteById(long id)
        {
            var existingEntity = _repo.MemberR.GetById(id);
            if (existingEntity != null)
            {
                existingEntity.Active = false;
                existingEntity.ModifiedDate = DateTime.Now;

                _repo.MemberR.Update(existingEntity);
                _repo.Save();
            }

        }
        public Member SoftDelete(Member member)
        {
            return member;
        }

        public Member FindById(long id)
        {
            return _repo.MemberR.GetById(id);
        }

        public IEnumerable<Member> Get()
        {
            return _repo.MemberR.GetAll();
        }



        public override void Dispose()
        {
            _repo?.Dispose();
        }

        public IEnumerable<Member> GetFilterable(MemberFilter filter)
        {
            filter.MemberName = filter.MemberName.Trim();
            filter.MobileNumber = filter.MobileNumber.Trim();

            var data = _repo.MemberR.GetFilterable(filter);
            return data;
        }
    }
}
