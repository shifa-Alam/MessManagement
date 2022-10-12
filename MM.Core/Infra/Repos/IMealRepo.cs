﻿using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IMealRepo : IGenericRepository<Meal>
    {
        //public Meal Save(Meal entity);
        //public Meal Update(Meal entity);
        //public void Delete(long id);
        //public Meal FindById(long id);
        //public IEnumerable<Meal> Get();
        //public IEnumerable<Meal> GetByMemberIdAndDateRange(long id, DateTime startDate, DateTime endDate);
        //void SaveRange(List<Meal> meals);


        IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
    }
}