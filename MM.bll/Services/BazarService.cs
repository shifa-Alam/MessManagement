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
    public class BazarService : BaseService, IBazarService
    {
        private IUnitOfWork _repo;
        public BazarService(IUnitOfWork repo)
        {
            _repo = repo;
        }
        public void Save(Bazar bazar)
        {
            bazar.Active = true;
            bazar.CreatedDate = DateTime.Now;

            _repo.BazarR.Add(bazar);
            _repo.Save();
        }

        public void Update(Bazar bazar)
        {
            var existingEntity = _repo.BazarR.GetById(bazar.Id);

            if (existingEntity != null)
            {
                existingEntity.Amount = bazar.Amount;
                existingEntity.BazarDate = bazar.BazarDate;
                existingEntity.ModifiedDate = DateTime.Now;

                _repo.BazarR.Update(existingEntity);
                _repo.Save();
            }

        }
        public void DeleteById(long id)
        {
            var bazar = _repo.BazarR.GetById(id);
            _repo.BazarR.Remove(bazar);
            _repo.Save();
        }
        public Bazar SoftDelete(Bazar bazar)
        {
            return bazar;
        }

        public Bazar FindById(long id)
        {
            return _repo.BazarR.GetById(id);
        }

        public IEnumerable<Bazar> Get()
        {
            return _repo.BazarR.GetAll();
        }

        public IEnumerable<Bazar> GetByMemberIdAndDateRange(long id, DateTime startDate, DateTime endDate)
        {
            return _repo.BazarR.GetByMemberIdAndDateRange(id, startDate, endDate);
        }


        public override void Dispose()
        {
            _repo?.Dispose();
        }
    }
}
