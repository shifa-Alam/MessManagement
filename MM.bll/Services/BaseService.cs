using MM.Core.Entities;
using MM.Core.Infra.Repos;
using MM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.bll.Services
{
    public abstract class BaseService : IBaseService
    {
        public abstract void Dispose();
        
    }
}
