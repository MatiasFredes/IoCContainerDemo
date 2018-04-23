using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer.Domain
{
    public class Shopper
    {
        public Shopper(ICreditCard creditCard)
        {
            CreditCard = creditCard;
        }

        public ICreditCard CreditCard { get; }

        public void Charge(decimal amount)
        {
            this.CreditCard.Charge(amount);
            Console.WriteLine("Has charged " + amount);
        }
    }
}
