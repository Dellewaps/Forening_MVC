using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeningGodtfolk.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IHistoryRepository History { get; private set; }
        public ICalenderRepository Calender { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            History = new HistoryRepository(_db);
            Calender = new CalenderRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
