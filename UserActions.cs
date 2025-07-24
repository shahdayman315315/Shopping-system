using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system
{
    internal class UserActions
    {
        Dictionary<string, double> Items = new Dictionary<string, double>() { { "Milk", 20 }, { "Rice", 7.5 }, { "Meat", 200 }, { "potato", 10 } };
        List<Tuple<string, double>> Cart = new List<Tuple<string, double>>();
        private double Totalprice = 0;
        Stack<Tuple<string,string,double>> Actions= new Stack<Tuple<string,string,double>>();

        public void AddItem()
        {
            Console.WriteLine("Choose from items: ");
            foreach (var item in Items) {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
            string item_name = Console.ReadLine();
            var item_exists = Items.FirstOrDefault(it=>it.Key.Equals(item_name,StringComparison.OrdinalIgnoreCase));
            if(item_exists.Key is null)
            {
                Console.WriteLine("Item not Found");
                return;
            }

            Actions.Push(Tuple.Create("Add", item_exists.Key, item_exists.Value));
            Cart.Add(Tuple.Create(item_exists.Key, item_exists.Value));
            Totalprice += item_exists.Value;
            Console.WriteLine("Item purchased successfully");
              

        }
        public void RemoveItem() {
            Console.WriteLine("Enter item you want to remove: ");
            string item_name = Console.ReadLine();
            var item_exists = Items.FirstOrDefault(it => it.Key.Equals(item_name, StringComparison.OrdinalIgnoreCase));
            if (item_exists.Key is null)
            {
                Console.WriteLine("Item not Purchased");
                return;
            }
            
            Actions.Push(Tuple.Create("Remove", item_exists.Key, item_exists.Value));
            double itemprice = item_exists.Value;
            Cart.Remove(Tuple.Create(item_exists.Key, item_exists.Value));
            Totalprice -= itemprice;
               
            Console.WriteLine("Item removed from your Cart");
        }
        public void ViewCart()
        {
            if(Cart.Count == 0)
            {
                Console.WriteLine("Your Cart is Empty");
                return;
            }
            Console.WriteLine("Items in your Cart: ");
            foreach (var item in Cart) {
                Console.Write(item.Item1 +"  " );
            }
            Console.WriteLine();
        }

        public void Check_out()
        {
            if (Cart.Count == 0)
            {
                Console.WriteLine("Your Cart is Empty");
                return;
            }
            Console.WriteLine("These are the Items you Purchased: ");
            foreach (var item in Cart) {
                Console.WriteLine($"Item:  {item.Item1} -> Price: {item.Item2} ");
            }
        }
        public void Total_price()
        {
            Console.WriteLine("Your Total Price is : "+Totalprice);
        }

        public void UNDO()
        {


            if (Actions.Count == 0)
            {
                Console.WriteLine("You have Done No Actions yet");
                return;
            }

            if (Actions.Peek().Item1 == "Add")
            {
                Cart.RemoveAt(Cart.Count - 1);
                string addeditem=Actions.Peek().Item2;
                Totalprice -= Actions.Pop().Item3;
                Console.WriteLine($"The Item {addeditem} was deleted from your Cart");
            }
            else
            {
                Cart.Add(Tuple.Create(Actions.Peek().Item2, Actions.Peek().Item3));
                Console.WriteLine($"The Item {Actions.Peek().Item2} was Added again ");
                Totalprice += Actions.Pop().Item3;
            }
        }
    }
}