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
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        private ApplicationDbContext _db;
        public HistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      
        public void Update(History obj)
        {
            var objFromDB = _db.Historys.FirstOrDefault(u => u.Id == obj.Id);
            if ( objFromDB != null)
            {
                objFromDB.Title = obj.Title;
                objFromDB.Description = obj.Description;
                objFromDB.Date = obj.Date;
                if (obj.ImageUrl != null)
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
