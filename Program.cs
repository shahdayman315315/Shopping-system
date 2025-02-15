namespace Shopping_system
{
    

namespace ConsoleApp1
    {
       

        internal class Program
        {

            static void Main(string[] args)
            {
                UserActions UA = new UserActions();

                string[] Actions = { "Add Items to Cart", "View Cart","Remove Items","Check out","Undo last action","Veiw Total Price","Exit" };
                bool looping = true;
                int highlightindex = 0;
                while (looping)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == highlightindex)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;

                        }
                        else
                        {

                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        Console.SetCursorPosition(60, (i) * (30 / 10));
                        Console.WriteLine(Actions[i]);
                    }
                    ConsoleKeyInfo info = Console.ReadKey();
                    switch (info.Key)
                    {
                        case ConsoleKey.DownArrow:
                            highlightindex++;
                            if (highlightindex == Actions.Length)
                                highlightindex = 0;
                            break;
                        case ConsoleKey.UpArrow:
                            highlightindex--;
                            if (highlightindex == 0)
                                highlightindex = Actions.Length - 1;
                            break;
                        
                        case ConsoleKey.Enter:
                            switch (highlightindex)
                            {
                                case 0:
                                    Console.Clear();
                                    UA.AddItem();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 1:
                                    Console.Clear();
                                    UA.ViewCart();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    UA.RemoveItem();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    UA.Check_out();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    UA.UNDO();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 5:
                                    Console.Clear();
                                    UA.Total_price();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 6:
                                    looping = false;
                                    break;
                            }
                            break;
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;

            }
           
            

        }
    }


}

