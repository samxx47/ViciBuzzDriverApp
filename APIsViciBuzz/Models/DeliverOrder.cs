using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIsViciBuzz.Models
{
    [BsonIgnoreExtraElements]
    public class DeliverOrder
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;


        [BsonElement("orderid")]
        public string orderid { get; set; } = String.Empty;

        [BsonElement("assignedto")]
        public string assignedto { get; set; } = String.Empty;

        [BsonElement("phonenumber")]
        public string phonenumber { get; set; } = String.Empty;

        [BsonElement("estimatedelivery")]
        public string estimatedelivery { get; set; } = String.Empty;

    }
}
