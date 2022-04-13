using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Strategy
{
    public class PayByCard : Payment
    {
        private string _cardNumber;
        private string _cvv;
        private DateOnly _expirationDate;
        public PayByCard(string cardNumber, string cvv, DateOnly expirationDate)
        {
            _cardNumber = cardNumber;
            _cvv = cvv;
            _expirationDate = expirationDate;
        }
        public void Pay(double price)
        {
            Console.WriteLine($"I paid {price} lei with my card having the number {_cardNumber} and the cvv {_cvv}");
        }
    }
}
