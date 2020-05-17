using System;
using System.Collections.Generic;
using System.Linq;

namespace P03ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            List<string> peopleInput = Console.ReadLine()
                 .Split(";")
                 .ToList();
            
            List<string> productsInput = Console.ReadLine()
                 .Split(";")
                 .ToList();
            for (int i = 0; i < peopleInput.Count; i++)
            {
                string[] currentPerson = peopleInput[i].Split("=");
                try
                {
                    Person person = new Person(currentPerson[0], decimal.Parse(currentPerson[1]));
                    people.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            for (int i = 0; i < productsInput.Count; i++)
            {
                string[] currentProduct = productsInput[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                if (currentProduct.Length <=1) { continue; }
                try
                {
                    Product product = new Product(currentProduct[0], decimal.Parse(currentProduct[1]));
                    products.Add(product);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = Console.ReadLine();
            while (command!="END")
            {
                string[] commandToArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = commandToArr[0];
                string productName = commandToArr[1];
                Person targetPerson = null;
                Product targetProduct = null;
                foreach (var person in people)
                {
                    if (person.Name == name)
                    {
                        targetPerson = person;
                    }
                }
                foreach (var product in products)
                {
                    if (product.Name == productName)
                    {
                        targetProduct = product;
                    }
                }
                if (targetPerson.Money >= targetProduct.Cost)
                {
                    Console.WriteLine($"{targetPerson.Name} bought {targetProduct.Name}");
                    targetPerson.AddProductToBag(targetProduct);
                    targetPerson.DecreaseMoney(targetProduct.Cost);
                    
                }
                else
                {
                    Console.WriteLine($"{targetPerson.Name} can't afford {targetProduct.Name}");
                }
                command = Console.ReadLine();
            }
            foreach (var person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    List<string> boughtProducts = new List<string>();
                    foreach (var item in person.Bag)
                    {
                        boughtProducts.Add(item.Name);
                    }
                    string personsBag = string.Join(", ", boughtProducts);
                    Console.WriteLine($"{person.Name} - {personsBag}");


                }

            }

        }
    }
}
