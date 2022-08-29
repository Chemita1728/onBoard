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
            UserMongo user = _hourCollection.Find(user => user.Name == name).Single();

            if (user!= null)
            {
                user.Hours.Add(new HourMongo { HourPressed = currentHour, UserName = name });
                _hourCollection.UpdateOne(p=> p._id==user._id, Builders<UserMongo>.Update.Set("Hours", user.Hours.ToBsonDocument()));
            }
            else
            {
                List<HourMongo> hoursList = new();

                UserMongo user_mongo = new UserMongo { Name = name, Hours = hoursList };

                user_mongo.Hours.Add(new HourMongo { HourPressed = currentHour, UserName = name });

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
            return _hourCollection.Find(user => user.Name == "").Single().Hours.Cast<Hour>().ToList();
        }
    }
}
