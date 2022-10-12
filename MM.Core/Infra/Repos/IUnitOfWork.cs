using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IBazarRepo BazarR
        {
            get;
        }
        IMealRepo MealR
        {
            get;
        }
        IMemberRepo MemberR
        {
            get;
        }
        int Save();
    }
}
