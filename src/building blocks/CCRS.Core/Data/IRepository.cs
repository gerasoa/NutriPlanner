﻿using CCRS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCRS.Core.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {    
        IUnifOfWork UnifOfWork { get; }
    }
}
