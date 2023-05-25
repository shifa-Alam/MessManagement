using MessManagement.Core.Helpers;
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Models.FilterModel;
using MM.Core.Services;


namespace MM.bll.Services
{
    public class FundService : BaseService, IFundService
    {
        private IUnitOfWork _repo;

        public FundService(IUnitOfWork repo)
        {
            _repo = repo;

        }
        public void Save(Fund fund)
        {
            fund.Active = true;
            fund.CreatedDate = DateTime.Now;
            _repo.FundR.Add(fund);

            _repo.Save();
        }

        public void Update(Fund fund)
        {
            var existingEntity = _repo.FundR.GetById(fund.Id);

            if (existingEntity != null)
            {
                existingEntity.Purpose = fund.Purpose;
                existingEntity.Amount = fund.Amount;
                existingEntity.IsDeduction = fund.IsDeduction;
                existingEntity.FundDate = fund.FundDate;
                existingEntity.ModifiedDate = DateTime.Now;

                _repo.FundR.Update(existingEntity);
                _repo.Save();
            }

        }
        public void DeleteById(long id)
        {
            var fund = _repo.FundR.GetById(id);
            _repo.FundR.Remove(fund);
            _repo.Save();
        }
        public Fund SoftDelete(Fund fund)
        {
            return fund;
        }

        public Fund FindById(long id)
        {
            return _repo.FundR.GetById(id);
        }

        public IEnumerable<Fund> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate)
        {
            return _repo.FundR.GetByMemberIdAndDateRange(memberId, startDate, endDate);
        }

        public void SaveRange(List<Fund> unds)
        {
            foreach (Fund fund in unds)
            {
                fund.Active = true;
                fund.CreatedDate = DateTime.Now;
            }
            _repo.FundR.AddRange(unds);
            _repo.Save();
        }

        public override void Dispose()
        {
            _repo?.Dispose();
        }

        public IEnumerable<Fund> Get(FundFilter filter)
        {
            if(filter.StartDate!=null && filter.EndDate != null)
            {
                filter.StartDate = DateUtil.StartOfTheDay((DateTime)filter.StartDate);
                filter.EndDate = DateUtil.EndOfTheDay((DateTime)filter.EndDate);
            }
           

            var data = _repo.FundR.GetFilterable(filter);
            return data;
        }       
    }
}
