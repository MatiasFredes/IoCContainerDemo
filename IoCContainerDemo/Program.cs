using IoCContainer.Container;
using IoCContainer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainerDemo
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Resolver resolver = new Resolver();
            ICreditCard creditCard = new Visa();
            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, Visa>();
            Shopper shopper = resolver.Resolve<Shopper>(); //new Shopper(creditCard);

            shopper.Charge(50);

            Console.ReadKey();
        }
    }
}
