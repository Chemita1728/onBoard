using MongoDB.Driver;
using MongoDB.Bson;

using onBoard.Models;

namespace onBoard.DBRepo
{
    public class DBRepoMongo : IDBRepo
    {
        private readonly IMongoCollection<UserMongo> _hourCollection;
        public DBRepoMongo()
        {
            var mongoClient = new MongoClient("mongodb://admin:2yqOCeggHXPp@mongodb.dev.inputforyou.local:27017/?ssl=false");
            var mongoDatabase = mongoClient.GetDatabase("onBoard");
            _hourCollection = mongoDatabase.GetCollection<UserMongo>("UserHour");
        }

        public Task<List<Hour>> AsyncGetList()
        {
            throw new NotImplementedException();
            //_hourCollection.Find(_ => true).ToListAsync<Hour>();
            //return _hourCollection.Find(_ => true).ToListAsync<Hour>();
        }

        public Task AsyncStoreTimeSpan(TimeSpan currentHour, string name)
        {
            bool exists =  _hourCollection.Find(_ => _.Name == name).Any();

            if (exists)
            {
                UserMongo user = _hourCollection.Find(user => user.Name == name).Single();
                user.Hours.Add(new Hour { HourPressed = currentHour, UserName = name });
                var filter = Builders<UserMongo>.Filter.Eq(p => p._id, user._id);
                _hourCollection.ReplaceOneAsync(filter, user);
            }
            else
            {
                List<Hour> hoursList = new();

                UserMongo user_mongo = new UserMongo { Name = name, Hours = hoursList };

                user_mongo.Hours.Add(new Hour { HourPressed = currentHour, UserName = name });

                _hourCollection.InsertOne(user_mongo);

            }

            return Task.CompletedTask;
        }

        public void StoreTimeSpan(TimeSpan currentHour, string name)
        {
            AsyncStoreTimeSpan(currentHour, name).Wait();
        }

        List<Hour> IDBRepo.GetList()
        {
            //return _hourCollection.Find(user => user.Name == "Armando Bronca Segura")?.Single().Hours.ToList();
            var collection = _hourCollection.Find(_ => true).ToList();
            List<Hour> sol = new List<Hour>();

            collection.ForEach(List<Hour> list in  )
            return _hourCollection.Find(_ => true)?.Single().Hours.ToList();
        }
    }
}
