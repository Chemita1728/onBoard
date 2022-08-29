﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace onBoard.Models
{
    public class HourMongo : Hour
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id;
    }
}
