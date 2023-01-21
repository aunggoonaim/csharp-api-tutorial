using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace csharp_api_tutorial.MongoDB
{
    public class PaymentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("OrderNo")]
        public string PaymentNo { get; set; } = null!;

        public decimal Price { get; set; }

        public string CreateBy { get; set; } = null!;

        public DateTime CreateDate { get; set; }
    }
}