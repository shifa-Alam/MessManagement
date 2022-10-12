using MM.Core.Entities;
using MM.Core.Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repo
{
    public class MemberRepo : GenericRepository<Member>, IMemberRepo
    {
        public MemberRepo(MMDBContext context) : base(context) { }






        //private readonly MMDBContext     _mmDbContext;

        //public MemberRepo(MMDBContext mmDbContext)
        //{
        //    _mmDbContext = mmDbContext;
        //}

        //public Member Save(Member member)
        //{
        //    var result = _mmDbContext.Members.Add(member);
        //    _mmDbContext.SaveChanges();
        //    return result.Entity;
        //}

        //public Member Update(Member m)
        //{
        //    var result = _mmDbContext.Members
        //            .FirstOrDefault(e => e.Id == m.Id);

        //    if (result != null)
        //    {
        //        result.FirstName = m.FirstName;
        //        result.LastName = m.LastName;
        //        result.MobileNumber = m.MobileNumber;
        //        result.HomeDistrict = m.HomeDistrict;
        //        result.ModifiedDate = DateTime.Now;

        //        _mmDbContext.SaveChanges();

        //        return result;
        //    }

        //    return null;
        //}
        //public void Delete(long id)
        //{
        //    var result =  _mmDbContext.Members
        //         .FirstOrDefault(e => e.Id == id);
        //    if (result != null)
        //    {
        //        _mmDbContext.Members.Remove(result);
        //         _mmDbContext.SaveChangesAsync();
        //    }

        //}

        //public Member FindById(long id)
        //{
        //    return _mmDbContext.Members.Find(id);
        //}

        //public IEnumerable<Member> Get()
        //{
        //   return _mmDbContext.Members.ToList();
        //}



    }
}
