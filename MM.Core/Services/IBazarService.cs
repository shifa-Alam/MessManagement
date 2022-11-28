using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public interface IBazarService: IBaseService
    {
        public void Save(Bazar entity);
        public void Update(Bazar entity);
        public void DeleteById(long id);
        public Bazar SoftDelete(Bazar entity);
        public Bazar FindById(long id);
        public IEnumerable<Bazar> Get();
        public IEnumerable<Bazar> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
    }
}
