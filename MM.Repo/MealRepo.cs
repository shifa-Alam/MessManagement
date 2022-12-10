using MessManagement.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Models.FilterModel;
using MM.Core.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repo
{
    public class MealRepo : GenericRepository<Meal>, IMealRepo
    {
        public MealRepo(MMDBContext context) : base(context) { }

        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = context.Meals.Where(e => e.MemberId == memberId && (e.MealDate >= startDate && e.MealDate <= endDate)).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override IEnumerable<Meal> GetAll()
        {
            var meals = context.Meals.Include(e => e.Member).OrderByDescending(e => e.MealDate).ToList();
            return meals;
        }

        public IEnumerable<Meal> GetWithFilter(MealFilter filter)
        {
            var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);
            var response = context.Meals?.Include(e => e.Member)
                .Where(e => e.MealDate >= filter.StartDate
                    && e.MealDate <= filter.EndDate
                    && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.MealDate)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize);


            return response;
        }
        public PagedResponse<List<Meal>> GetWithFilterReplica(MealFilter filter)
        {
            var validFilter = new BaseFilter(filter.PageNumber, filter.PageSize);
            var response = context.Meals?.Include(e => e.Member)
                .Where(e => e.MealDate >= filter.StartDate
                    && e.MealDate <= filter.EndDate
                    && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true))
                .OrderByDescending(e => e.MealDate)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize);


            var finalResponse = new PagedResponse<List<Meal>>(response.ToList(), filter.PageNumber, filter.PageSize);

            finalResponse.TotalRecords = context.Meals
                .Where(e => e.MealDate >= filter.StartDate
                    && e.MealDate <= filter.EndDate
                    && (!string.IsNullOrEmpty(filter.MemberName) ? (e.Member.FirstName.Contains(filter.MemberName) || e.Member.LastName.Contains(filter.MemberName)) : true)
                    
                    ).Count();



            return finalResponse;
        }
    }


    //public class MealRepo : IMealRepo
    //{
    //    private readonly MMDBContext _mmDbContext;

    //    public MealRepo(MMDBContext mmDbContext)
    //    {
    //        _mmDbContext = mmDbContext;
    //    }

    //    public Meal Save(Meal Meal)
    //    {
    //        var result = _mmDbContext.Meals.Add(Meal);
    //        _mmDbContext.SaveChanges();
    //        return result.Entity;
    //    }
    //    public void SaveRange(List<Meal> meals)
    //    {
    //       _mmDbContext.Meals.AddRange(meals);
    //        _mmDbContext.SaveChanges();
    //    }

    //    public Meal Update(Meal m)
    //    {
    //        var result = _mmDbContext.Meals
    //                .FirstOrDefault(e => e.Id == m.Id);

    //        if (result != null)
    //        {
    //            result.Quantity = m.Quantity;
    //            result.MealDate = m.MealDate;
    //            result.ModifiedDate = DateTime.Now;

    //            _mmDbContext.SaveChanges();

    //            return result;
    //        }

    //        return null;
    //    }
    //    public void Delete(long id)
    //    {
    //        var result = _mmDbContext.Meals
    //             .FirstOrDefault(e => e.Id == id);
    //        if (result != null)
    //        {
    //            _mmDbContext.Meals.Remove(result);
    //            _mmDbContext.SaveChangesAsync();
    //        }

    //    }

    //    public Meal FindById(long id)
    //    {
    //        var Meal = _mmDbContext.Meals.Find(id);
    //        return Meal;
    //    }

    //    public IEnumerable<Meal> Get()
    //    {

    //        return _mmDbContext.Meals.Include(e => e.Member).ToList();
    //    }



    //    public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
    //    {
    //        try
    //        {
    //            var result = _mmDbContext.Meals;
    //            var x= result.Where(e => e.MemberId == memberId && (e.MealDate >= startDate && e.MealDate <= endDate)).ToList();

    //            return x;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }


    //}


}
