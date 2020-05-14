using System;
using System.Collections.Generic;
using System.Linq;
using P04P05P06BorderControl;

namespace P04BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //P04.
            //string command;
            //List<IResident> people = new List<IResident>();
            //while ((command = Console.ReadLine()) != "End")
            //{
            //    string[] input = command
            //        .Split()
            //        .ToArray();
            //    if (input.Length == 2)
            //    {
            //        string model = input[0];
            //        string id = input[1];
            //        Robot robot = new Robot(model, id);
            //        people.Add(robot);

            //    }
            //    else if (input.Length == 3)
            //    {
            //        string name = input[0];
            //        int age = int.Parse(input[1]);
            //        string id = input[2];
            //        Citizen citizen = new Citizen(name, age, id);
            //        people.Add(citizen);
            //    }
            //}
            //int number = int.Parse(Console.ReadLine());
            //foreach (var item in people)
            //{
            //    string currentId = item.Id;
            //    bool match = true;
            //    int j = number.ToString().Length;
            //    for (int i = currentId.Length - 1; i >= currentId.Length - number.ToString().Length; i--)
            //    {
            //        j--;
            //        if (currentId[i] != number.ToString()[j])
            //        {
            //            match = false;
            //        }
            //    }
            //    if (match == true)
            //    {
            //        Console.WriteLine(currentId);
            //    }
            //}





            //P05.
            //string command;
            //List<IBirthable> people = new List<IBirthable>();

            //while ((command=Console.ReadLine())!="End")
            //{
            //    string[] input = command
            //        .Split()
            //        .ToArray();

            //    string cmdType = input[0];
            //    if (cmdType == "Citizen")
            //    {
            //        string name = input[1];
            //        int age = int.Parse(input[2]);
            //        string id = input[3];
            //        string birthDate = (input[4]);
            //        Citizen citizen = new Citizen(name, age, id, birthDate);
            //        people.Add(citizen);
            //    }
            //    else if (cmdType == "Robot")
            //    {
            //        string model = input[1];
            //        string id = input[2];
            //        Robot robot = new Robot(model, id);

            //    }
            //    else if (cmdType == "Pet")
            //    {
            //        string name = input[1];
            //        string birthDate = (input[2]);
            //        Pet pet = new Pet(name, birthDate);
            //        people.Add(pet);

            //    }

            //}
            //int year = int.Parse(Console.ReadLine());
            //foreach (var item in people)
            //{
            //    string currentBirthDate = item.Birthdate;
            //    //int currentYear = currentBirthDate.Year;
            //    int[] birthdateSplit = currentBirthDate.Split('/').Select(int.Parse).ToArray();
            //    int currentYear = birthdateSplit[2];
            //    if (currentYear == year)
            //    {
            //        Console.WriteLine(currentBirthDate);
            //        //string result = string.Format($"{currentBirthDate.Day}/{currentBirthDate.Month}/{currentBirthDate.Year}");
            //        //DateTime sth = new DateTime(currentBirthDate.Day, currentBirthDate.Month, currentBirthDate.Year);
            //        //Console.WriteLine(sth);



            //    }
            //}

            //P06.
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = command[0];
                int age = int.Parse(command[1]);

                if (command.Length == 4)
                { 
                    string id = command[2];
                    string birthdate = command[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else if (command.Length == 3)
                {
                    string group = command[2];
                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }
            string inputName ;
            int totalFood = 0;
            int food = 0;
            while ((inputName = Console.ReadLine()) != "End")
            {
                if (buyers.Any(n => n.Name == inputName))
                {
                    IBuyer buyer = buyers.First(n => n.Name == inputName);
                    food=buyer.BuyFood();
                    totalFood += food;

                }
            }
            int sum=buyers.Sum(b => b.Food);
            Console.WriteLine(sum);
            
        }
    }
}
