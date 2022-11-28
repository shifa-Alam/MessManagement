using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Services;


namespace MM.bll.Services
{
    public class MealService : BaseService, IMealService
    {
        private IUnitOfWork _repo;

        public MealService(IUnitOfWork repo)
        {
            _repo = repo;

        }
        public void Save(Meal meal)
        {
            meal.Active = true;
            meal.CreatedDate = DateTime.Now;
            _repo.MealR.Add(meal);

            _repo.Save();
        }

        public void Update(Meal meal)
        {
            var existingEntity = _repo.MealR.GetById(meal.Id);

            if (existingEntity != null)
            {
                existingEntity.Quantity = meal.Quantity;
                existingEntity.MealDate = meal.MealDate;
                existingEntity.ModifiedDate = DateTime.Now;

                _repo.MealR.Update(existingEntity);
                _repo.Save();
            }

        }
        public void DeleteById(long id)
        {
            var meal = _repo.MealR.GetById(id);
            _repo.MealR.Remove(meal);
            _repo.Save();
        }
        public Meal SoftDelete(Meal meal)
        {
            return meal;
        }

        public Meal FindById(long id)
        {
            return _repo.MealR.GetById(id);
        }

        public IEnumerable<Meal> Get()
        {
            return _repo.MealR.GetAll();
        }

        public IEnumerable<Meal> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            return _repo.MealR.GetByMemberIdAndDateRange(memberId, startDate, endDate);
        }

        public void SaveRange(List<Meal> meals)
        {
            foreach (Meal meal in meals)
            {
                meal.Active = true;
                meal.CreatedDate = DateTime.Now;
            }
            _repo.MealR.AddRange(meals);
            _repo.Save();
        }
      
        public override void Dispose()
        {
            _repo?.Dispose();
        }
    }
}
