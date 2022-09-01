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
            return _context.Hours.AsNoTracking().OrderByDescending(x => x.HourPressed).ToListAsync();
        }

        public async Task AsyncStoreTimeSpan(TimeSpan currentHour, string name)
        {
            if (_context.Users.Find(name) is null)
            {
                User user = new User { Name = name };
                _context.Add(user);
            }
            Hour hour = new Hour { UserName = name, HourPressed = currentHour };
            _context.Add(hour);
            await _context.SaveChangesAsync();
        }

        public List<Hour> GetList()
        {
            return _context.Hours.AsNoTracking().OrderByDescending(x => x.HourPressed).ToList();
        }

        public void StoreTimeSpan(TimeSpan currentHour, string name)
        {
            if (_context.Users.Find(name) is null)
            {
                User user = new User { Name = name };
                _context.Add(user);
            }
            Hour hour = new Hour { UserName = name, HourPressed = currentHour };
            _context.Add(hour);
            _context.SaveChanges();
        }
<<<<<<< Updated upstream
=======

        public virtual int GetClicksByUser(string userName)
        {
            return _context.Hours.Count(x => x.UserName == userName);

        }
>>>>>>> Stashed changes
    }
}
