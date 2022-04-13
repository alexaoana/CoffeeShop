using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Strategy
{
    public class Context
    {
        private Payment _payment;
        public Context(Payment payment)
        {
            _payment = payment;
        }

        public void executePayment(double price)
        {
            _payment.Pay(price);
        }
    }
}
