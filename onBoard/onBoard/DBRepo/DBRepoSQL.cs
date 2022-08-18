using onBoard.Models;

namespace onBoard.DBRepo
{
    public class DBRepoSQL : IDBRepo<Hour>
    {
        public Task<List<Hour>> AsyncGetList(int? offset = null, int? limit = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AsyncStoreTimeSpan(TimeSpan currentHour)
        {
            throw new NotImplementedException();
        }

        public List<Hour> GetList(int? offset = null, int? limit = null)
        {
            throw new NotImplementedException();
        }

        public bool StoreTimeSpan(TimeSpan currentHour)
        {
            throw new NotImplementedException();
        }
    }
}
