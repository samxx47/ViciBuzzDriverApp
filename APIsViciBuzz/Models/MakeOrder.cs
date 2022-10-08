﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIsViciBuzz.Models
{
    [BsonIgnoreExtraElements]
    public class MakeOrder
    {
        
       
        
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; } = String.Empty;


            [BsonElement("title")]
            public string Title { get; set; } = String.Empty;

            [BsonElement("discription")]
            public string Discription { get; set; } = String.Empty;

            [BsonElement("deliverto")]
            public string deliverto { get; set; } = String.Empty;

            [BsonElement("pickupfrom")]
            public string pickupfrom { get; set; } = String.Empty;

            [BsonElement("madeby")]
            public string madeby { get; set; } = String.Empty;

            [BsonElement("tolat")]
            public string tolat { get; set; } = String.Empty;

            [BsonElement("tolon")]
            public string tolon { get; set; } = String.Empty;

            [BsonElement("fromlat")]
            public string fromlat { get; set; } = String.Empty;
           
           
            [BsonElement("fromlon")]
            public string fromlon { get; set; } = String.Empty;







    }
}
