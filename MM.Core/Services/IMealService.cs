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
        public void Save(Meal entity);
        public void SaveRange(List<Meal> meals);
        public void Update(Meal entity);
        public void DeleteById(long id);
        public Meal SoftDelete(Meal entity);
        public Meal FindById(long id);
        public IEnumerable<Meal> Get();
        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
    }
}
