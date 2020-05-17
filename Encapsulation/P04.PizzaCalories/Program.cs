using System;
using System.Linq;

namespace P04PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] command = Console.ReadLine().Split();
                if (command != null)
                {
                    Pizza pizza = new Pizza(command[1]);
                    command = Console.ReadLine().Split();
                    if (command != null)
                    {
                        pizza.Dough = new Dough(command[1], command[2], int.Parse(command[3]));
                        string input;
                        while ((input=Console.ReadLine())!="END")
                        {
                            if (input != null)
                            {
                                command = input.Split();
                            }
                            pizza.AddTopping(new Topping(command[1], int.Parse(command[2])));
                        }
                        Console.WriteLine(pizza);
                    }


                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}
