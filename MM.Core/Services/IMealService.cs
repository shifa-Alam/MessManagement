using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public  interface IMealService
    {
        public Meal Save(Meal meal);
        public Meal Update(Meal meal);
        public void DeleteById(long id);
        public Meal SoftDelete(Meal meal);
        public Meal FindById(long id);
        public IEnumerable<Meal> Get();
    }
}
