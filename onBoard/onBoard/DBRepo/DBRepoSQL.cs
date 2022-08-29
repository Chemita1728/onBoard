using Microsoft.EntityFrameworkCore;
using onBoard.Data;
using onBoard.Models;


//_context.Database.GetDbConnection().GetType();

namespace onBoard.DBRepo
{
    public class DBRepoSQL : IDBRepo
    {
        private readonly ProjectContext _context;

        public DBRepoSQL( ProjectContext context)
        {
            _context = context;
        }
        public Task<List<Hour>> AsyncGetList()
        {
            return _context.Hours.AsNoTracking().OrderByDescending(x => x.HourPressed).ToListAsync<Hour>();
        }

        public async Task AsyncStoreTimeSpan(TimeSpan currentHour, string name)
        {
            if (_context.Users.Find(name) is null)
            {
                User user = new User { Name = name };
                _context.Add(user);
            }
            HourSQL hour = new HourSQL { UserName = name, HourPressed = currentHour };
            _context.Add(hour);
            await _context.SaveChangesAsync();
        }

        public List<Hour> GetList()
        {
            try
            {
                //var hoursSQL = _context.Hours.AsNoTracking().OrderByDescending(x => x.HourPressed).ToList();
                //var hours = hoursSQL.ConvertAll<Hour>(p => (Hour)p);
            

                return _context.Hours.AsNoTracking()
                    .OrderByDescending(x => x.HourPressed)
                    .ToList()
                    .ConvertAll<Hour>(p => (Hour)p);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void StoreTimeSpan(TimeSpan currentHour, string name)
        {
            if (_context.Users.Find(name) is null)
            {
                User user = new User { Name = name };
                _context.Add(user);
            }
            HourSQL hour = new HourSQL { UserName = name, HourPressed = currentHour };
            _context.Add(hour);
            _context.SaveChanges();
        }
    }
}
