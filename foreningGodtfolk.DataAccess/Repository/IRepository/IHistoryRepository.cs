using ForeningGodtfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeningGodtfolk.DataAccess.Repository.IRepository
{
    public interface ICalenderRepository : IRepository<Calender>
    {
        void Update(Calender obj);
    }
}
