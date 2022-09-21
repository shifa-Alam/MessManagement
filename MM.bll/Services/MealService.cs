﻿using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.bll.Services
{
    public class MealService : IMealService
    {
        private IMealRepo _mealRepo;
       
        public MealService(IMealRepo mealRepo)
        {
            _mealRepo = mealRepo;
           
        }
        public Meal Save(Meal meal)
        {
            meal.Active = true;
            meal.CreatedDate = DateTime.Now;
            return _mealRepo.Save(meal);
        }

        public Meal Update(Meal meal)
        {
            return _mealRepo.Update(meal);
        }
        public void DeleteById(long id)
        {
            _mealRepo.Delete(id);
        }
        public Meal SoftDelete(Meal meal)
        {
            return meal;
        }

        public Meal FindById(long id)
        {
            return _mealRepo.FindById(id);
        }

        public IEnumerable<Meal> Get()
        {
            return _mealRepo.Get();
        }

        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            return _mealRepo.GetByMemberIdAndDateRange(memberId,startDate,endDate);
        }
    }
}
