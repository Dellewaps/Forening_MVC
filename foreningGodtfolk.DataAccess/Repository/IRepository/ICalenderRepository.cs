using ForeningGodtfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeningGodtfolk.DataAccess.Repository.IRepository
{
    public interface IHistoryRepository : IRepository<History>
    {
        void Update(History obj);
    }
}
