using MessManagement.Core.Helpers;
using MM.Core.Entities;
using MM.Core.Models.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Services
{
    public interface IMealService : IBaseService
    {
        public void Save(Meal entity);
        public void SaveRange(List<Meal> meals);
        public void Update(Meal entity);
        public void DeleteById(long id);
        public Meal SoftDelete(Meal entity);
        public Meal FindById(long id);
        public IEnumerable<Meal> Get(MealFilter filter);
        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
    }
}
