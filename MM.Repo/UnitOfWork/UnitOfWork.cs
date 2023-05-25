
using MM.Core.Entities;
using MM.Core.Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private MMDBContext _context;
        public UnitOfWork(MMDBContext context)
        {
            _context = context;
            MealR = new MealRepo(_context);
            MemberR = new MemberRepo(_context);
            BazarR = new BazarRepo(_context);
            FundR = new FundRepo(_context);
        }
        public IMealRepo MealR
        {
            get;
            private set;
        }
        public IFundRepo FundR
        {
            get;
            private set;
        }

        public IBazarRepo BazarR
        {
            get;
            private set;
        }
        public IMemberRepo MemberR
        {
            get;
            private set;
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
