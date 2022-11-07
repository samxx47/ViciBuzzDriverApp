using APIsViciBuzz.Models;
using MongoDB.Driver;

namespace APIsViciBuzz.Services
{
    public class DeliverOrderService : IDeliverOrderService
    {
        private readonly IMongoCollection<DeliverOrder> _deliverorder;


        public DeliverOrderService(IMakeOrderStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _deliverorder = database.GetCollection<DeliverOrder>(settings.MakeOrderCollectionName);

        }
        public DeliverOrder Create(DeliverOrder deliverOrder)
        {
            deliverOrder.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _deliverorder.InsertOne(deliverOrder);
            return deliverOrder;
        }

        public List<DeliverOrder> Get()
        {
            return _deliverorder.Find(deliverOrder => true).ToList();
        }

        public DeliverOrder Get(string id)
        {
            return _deliverorder.Find(deliverOrder => deliverOrder.Id == id).FirstOrDefault();
        }


        public void Remove(string id)
        {
            _deliverorder.DeleteOne(deliverOrder => deliverOrder.Id == id);
        }

        public void Update(string id, DeliverOrder deliverOrder)
        {
            _deliverorder.ReplaceOne(deliverOrder => deliverOrder.Id == id, deliverOrder);
        }
    }
}
