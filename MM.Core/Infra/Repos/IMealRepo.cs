using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IMealRepo
    {
        public Meal Save(Meal meal);
        public Meal Update(Meal m);
        public void Delete(long id);
        public Meal FindById(long id);
        public IEnumerable<Meal> Get();
    }
}
