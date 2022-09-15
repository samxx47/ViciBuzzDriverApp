using APIsViciBuzz.Models;
using MongoDB.Driver;

namespace APIsViciBuzz.Services
{
    public class MakeOrderService : IMakeOrderService
    {
        private readonly IMongoCollection<MakeOrder> _makeorder;

        public MakeOrderService( IMakeOrderStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _makeorder = database.GetCollection<MakeOrder>(settings.MakeOrderCollectionName);

        }

        public MakeOrder Create(MakeOrder makeOrder)
        {
            makeOrder.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _makeorder.InsertOne(makeOrder);
            return makeOrder;   
        }

        public List<MakeOrder> Get()
        {
            return _makeorder.Find(makeOrder => true).ToList();
        }

        public MakeOrder Get(string id)
        {
            return _makeorder.Find(makeOrder => makeOrder.Id==id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _makeorder.DeleteOne(makeOrder => makeOrder.Id == id);
        }

        public void Update(string id, MakeOrder makeOrders)
        {
            _makeorder.ReplaceOne(makeOrders => makeOrders.Id == id, makeOrders);
        }
    }
}
