using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace onBoard.Models
{
    public class UserMongo:User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
    }
}