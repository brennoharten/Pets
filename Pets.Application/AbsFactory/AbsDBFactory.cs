using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Application.AbsFactory
{
    public abstract class AbsDBFactory
    {
        public abstract IDbConnection CreateConnection();
    }
}