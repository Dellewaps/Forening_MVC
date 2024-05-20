using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeningGodtfolk.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IHistoryRepository History { get; }
        ICalenderRepository Calender { get; }

        void Save();
    }
}
