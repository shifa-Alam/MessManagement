﻿using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Core.Infra.Repos
{
    public interface IBazarRepo
    {
        public Bazar Save(Bazar entity);
        public Bazar Update(Bazar m);
        public void Delete(long id);
        public Bazar FindById(long id);
        public IEnumerable<Bazar> Get();
    }
}
