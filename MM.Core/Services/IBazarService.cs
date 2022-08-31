using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public  interface IBazarService
    {
        public Bazar Save(Bazar entity);
        public Bazar Update(Bazar entity);
        public void DeleteById(long id);
        public Bazar SoftDelete(Bazar entity);
        public Bazar FindById(long id);
        public IEnumerable<Bazar> Get();
    }
}
