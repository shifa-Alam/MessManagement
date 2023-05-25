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
    public interface IFundService : IBaseService
    {
        public void Save(Fund entity);
        public void SaveRange(List<Fund> meals);
        public void Update(Fund entity);
        public void DeleteById(long id);
        public Fund SoftDelete(Fund entity);
        public Fund FindById(long id);
        public IEnumerable<Fund> Get(FundFilter filter);
        public IEnumerable<Fund> GetByMemberIdAndDateRange(long memberId, DateTime startDate, DateTime endDate);
    }
}
