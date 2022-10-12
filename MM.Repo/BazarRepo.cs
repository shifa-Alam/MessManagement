using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repo
{
    public class BazarRepo : GenericRepository<Bazar>, IBazarRepo
    {
        public BazarRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Bazar> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = context.Bazars.Where(e => e.MemberId == memberId && e.BazarDate >= startDate && e.BazarDate <= endDate).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override IEnumerable<Bazar> GetAll()
        {
            var bazars = context.Bazars.Include(e => e.Member).OrderByDescending(e => e.BazarDate).ToList();
            return bazars;
        }

        //private readonly MMDBContext     _mmDbContext;

        //public BazarRepo(MMDBContext mmDbContext)
        //{
        //    _mmDbContext = mmDbContext;
        //}

        //public Bazar Save(Bazar Bazar)
        //{
        //    var result = _mmDbContext.Bazars.Add(Bazar);
        //    _mmDbContext.SaveChanges();
        //    return result.Entity;
        //}

        //public Bazar Update(Bazar m)
        //{
        //    var result = _mmDbContext.Bazars
        //            .FirstOrDefault(e => e.Id == m.Id);

        //    if (result != null)
        //    {
        //        result.Amount = m.Amount;
        //        result.BazarDate = m.BazarDate;
        //        result.ModifiedDate = DateTime.Now;

        //        _mmDbContext.SaveChanges();

        //        return result;
        //    }

        //    return null;
        //}
        //public void Delete(long id)
        //{
        //    var result =  _mmDbContext.Bazars
        //         .FirstOrDefault(e => e.Id == id);
        //    if (result != null)
        //    {
        //        _mmDbContext.Bazars.Remove(result);
        //         _mmDbContext.SaveChangesAsync();
        //    }

        //}

        //public Bazar FindById(long id)
        //{
        //    var Bazar = _mmDbContext.Bazars.Find(id);
        //    return Bazar;
        //}

        //public IEnumerable<Bazar> Get()
        //{

        //   return _mmDbContext.Bazars.Include(e=>e.Member).ToList();
        //}

        //public IEnumerable<Bazar> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        //    {
        //        try
        //        {
        //            IQueryable<Bazar> result = _mmDbContext.Bazars;

        //            return result.Where(e => e.MemberId == memberId && e.BazarDate >= startDate && e.BazarDate <= endDate).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }
    }
}
