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
    public class BazarService : IBazarService
    {
        private IBazarRepo _bazarRepo;
        public BazarService(IBazarRepo bazarRepo)
        {
            _bazarRepo = bazarRepo;
        }
        public Bazar Save(Bazar bazar)
        {
            bazar.Active = true;
            bazar.CreatedDate = DateTime.Now;
            return _bazarRepo.Save(bazar);
        }

        public Bazar Update(Bazar bazar)
        {
            return _bazarRepo.Update(bazar);
        }
        public void DeleteById(long id)
        {
            _bazarRepo.Delete(id);
        }
        public Bazar SoftDelete(Bazar bazar)
        {
            return bazar;
        }

        public Bazar FindById(long id)
        {
            return _bazarRepo.FindById(id);
        }

        public IEnumerable<Bazar> Get()
        {
            return _bazarRepo.Get();
        }
    }
}
