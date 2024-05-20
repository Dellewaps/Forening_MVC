using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.DataAcess.Data;
using ForeningGodtfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForeningGodtfolk.DataAccess.Repository
{
    public class CalenderRepository : Repository<Calender>, ICalenderRepository
    {
        private ApplicationDbContext _db;
        public CalenderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      
        public void Update(Calender obj)
        {
            _db.Calender.Update(obj);
        }
    }
}
