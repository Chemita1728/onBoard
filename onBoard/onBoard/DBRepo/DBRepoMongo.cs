using MongoDB.Driver;
using MongoDB.Bson;

using onBoard.Models;

namespace onBoard.DBRepo
{
    public class DBRepoMongo : IDBRepo
    {
        private readonly IMongoCollection<HourMongo> _hourCollection;
        public DBRepoMongo()
        {
            var mongoClient = new MongoClient("mongodb://admin:2yqOCeggHXPp@mongodb.dev.inputforyou.local:27017/?ssl=false");
            var mongoDatabase = mongoClient.GetDatabase("onBoard");
            _hourCollection = mongoDatabase.GetCollection<HourMongo>("UserHour");
        }

        public Task<List<Hour>> AsyncGetList()
        {
            throw new NotImplementedException();
            //_hourCollection.Find(_ => true).ToListAsync<Hour>();
            //return _hourCollection.Find(_ => true).ToListAsync<Hour>();
        }

        public async Task AsyncStoreTimeSpan(TimeSpan currentHour, string name)
        {
            throw new NotImplementedException();
        }

        public List<Hour> GetList()
        {
            //return mongoDatabase.Hours.find( { $orderBy: { weight: -1 } }).ToList();
            return _hourCollection.Find(_ => true).ToList().ConvertAll<Hour>(p => (Hour)p);
        }

        public void StoreTimeSpan(TimeSpan currentHour, string name)
        {
            //User user = new User { Name = name };
            //mongoDatabase.Users.insertOne(user);
            HourMongo hour = new HourMongo { UserName = name, HourPressed = currentHour };
            _hourCollection.InsertOne(hour);
        }
    }
}
