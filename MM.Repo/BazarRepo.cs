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
    public class BazarRepo : IBazarRepo
    {
        private readonly MMDBContext     _mmDbContext;

        public BazarRepo(MMDBContext mmDbContext)
        {
            _mmDbContext = mmDbContext;
        }

        public Bazar Save(Bazar Bazar)
        {
            var result = _mmDbContext.Bazars.Add(Bazar);
            _mmDbContext.SaveChanges();
            return result.Entity;
        }

        public Bazar Update(Bazar m)
        {
            var result = _mmDbContext.Bazars
                    .FirstOrDefault(e => e.Id == m.Id);

            if (result != null)
            {
                result.Amount = m.Amount;
                result.BazarDate = m.BazarDate;
                result.ModifiedDate = DateTime.Now;

                _mmDbContext.SaveChanges();

                return result;
            }

            return null;
        }
        public void Delete(long id)
        {
            var result =  _mmDbContext.Bazars
                 .FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                _mmDbContext.Bazars.Remove(result);
                 _mmDbContext.SaveChangesAsync();
            }

        }

        public Bazar FindById(long id)
        {
            var Bazar = _mmDbContext.Bazars.Find(id);
            return Bazar;
        }

        public IEnumerable<Bazar> Get()
        {
            
           return _mmDbContext.Bazars.Include(e=>e.Member).ToList();
        }

       
    }
}
