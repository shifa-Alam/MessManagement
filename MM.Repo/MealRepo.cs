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
    public class MealRepo : IMealRepo
    {
        private readonly MMDBContext     _mmDbContext;

        public MealRepo(MMDBContext mmDbContext)
        {
            _mmDbContext = mmDbContext;
        }

        public Meal Save(Meal Meal)
        {
            var result = _mmDbContext.Meals.Add(Meal);
            _mmDbContext.SaveChanges();
            return result.Entity;
        }

        public Meal Update(Meal m)
        {
            var result = _mmDbContext.Meals
                    .FirstOrDefault(e => e.Id == m.Id);

            if (result != null)
            {
                result.Quantity = m.Quantity;
                result.MealDate = m.MealDate;
                result.ModifiedDate = DateTime.Now;

                _mmDbContext.SaveChanges();

                return result;
            }

            return null;
        }
        public void Delete(long id)
        {
            var result =  _mmDbContext.Meals
                 .FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                _mmDbContext.Meals.Remove(result);
                 _mmDbContext.SaveChangesAsync();
            }

        }

        public Meal FindById(long id)
        {
            var Meal = _mmDbContext.Meals.Find(id);
            return Meal;
        }

        public IEnumerable<Meal> Get()
        {
            
           return _mmDbContext.Meals.ToList();
        }

       
    }
}
