using onBoard.Models;

namespace onBoard.DBRepo
{
    public interface IDBRepo
    {
        public void StoreTimeSpan(TimeSpan currentHour, string name);
        public Task AsyncStoreTimeSpan(TimeSpan currentHour, string name);
        public List<Hour> GetList();
        public Task<List<Hour>> AsyncGetList();
    }
}
