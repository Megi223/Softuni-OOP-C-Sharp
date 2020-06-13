using System;
using System.Collections.Generic;
using System.Linq;
using P04WildFarm.Models;

namespace P04WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<Animal> animals = new List<Animal>();
            while ((command=Console.ReadLine())!="End")
            {
                string[] cmdArgs = command.Split().ToArray();

                string animalType = cmdArgs[0];
                string name = cmdArgs[1];
                double weight = double.Parse(cmdArgs[2]);

                if (animalType == "Owl")
                {
                    Owl owl = new Owl(name, weight, double.Parse(cmdArgs[3]));
                    animals.Add(owl);
                    Console.WriteLine(Sound(owl));
                }
                else if (animalType == "Hen")
                {
                    Hen hen = new Hen(name, weight, double.Parse(cmdArgs[3]));
                    animals.Add(hen);
                    Console.WriteLine(Sound(hen));


                }
                else if (animalType == "Mouse")
                {
                    Mouse mouse = new Mouse(name, weight, cmdArgs[3]);
                    animals.Add(mouse);
                    Console.WriteLine(Sound(mouse));


                }
                else if (animalType == "Dog")
                {
                    Dog dog = new Dog(name, weight, cmdArgs[3]);
                    animals.Add(dog);
                    Console.WriteLine(Sound(dog));


                }
                else if (animalType == "Cat")
                {
                    Cat cat = new Cat(name, weight, cmdArgs[3], cmdArgs[4]);
                    animals.Add(cat);
                    Console.WriteLine(Sound(cat));


                }
                else if (animalType == "Tiger")
                {
                    Tiger tiger = new Tiger(name, weight, cmdArgs[3], cmdArgs[4]);
                    animals.Add(tiger);
                    Console.WriteLine(Sound(tiger));



                }

                string[] foodArgs = Console.ReadLine()
                    .Split()
                    .ToArray();
                string TypeOfFood = foodArgs[0];
                int quantityOfFood = int.Parse(foodArgs[1]);
                try
                {
                    Animal currentAnimal = animals.Last();
                    currentAnimal.Eat(TypeOfFood, quantityOfFood);
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            
        }

        private static string Sound(Animal animal)
        {
           return animal.ProduceSound();
        }
    }
}
