using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCRS.Core.Data
{
    public interface IUnifOfWork
    {
        Task<bool> Commit();
    }
}
