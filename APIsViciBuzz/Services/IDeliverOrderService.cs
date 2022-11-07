using APIsViciBuzz.Models;

namespace APIsViciBuzz.Services
{
    public interface IDeliverOrderService
    {
        public DeliverOrder Create(DeliverOrder deliverOrder);

        public List<DeliverOrder> Get();

        public DeliverOrder Get(string id);
    }
}
