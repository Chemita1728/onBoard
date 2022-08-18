namespace onBoard.DBRepo
{
    public interface IDBRepo<T>
    {
        public bool StoreTimeSpan(TimeSpan currentHour);
        public Task<bool> AsyncStoreTimeSpan(TimeSpan currentHour);

        public List<T> GetList(int? offset = null, int? limit = null);
        public Task<List<T>> AsyncGetList(int? offset = null, int? limit = null);
    }
}
