using APIsViciBuzz.Models;

namespace APIsViciBuzz.Services
{
    public interface IMakeOrderService
    {
        public MakeOrder Create(MakeOrder makeOrder);

        public List<MakeOrder> Get();

        public MakeOrder Get(string id);
    }
}
