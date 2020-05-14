using System;
using System.Linq;

namespace P03Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] sites = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currentPhoneNumber = phoneNumbers[i];
                if(!int.TryParse(currentPhoneNumber,out int sth))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (currentPhoneNumber.Length == 7)
                {
                    var phone = new StationaryPhone();
                    string result = string.Format(phone.Call(), currentPhoneNumber);
                    Console.WriteLine(result);
                }
                else if (currentPhoneNumber.Length == 10)
                {
                    var phone = new Smartphone();
                    string result = string.Format(phone.Call(), currentPhoneNumber);
                    Console.WriteLine(result);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                string currentSite = sites[i];
                bool thereIsPrinted = false;

                for (int j = 0; j < currentSite.Length; j++)
                {
                    if (Char.IsDigit(currentSite[j]))
                    {
                        Console.WriteLine("Invalid URL!");
                        thereIsPrinted = true;
                        break;
                        
                    }
                }
                if (thereIsPrinted == true)
                {
                    continue;
                }
                var phone = new Smartphone();
                string result = string.Format(phone.Browse(), currentSite);
                Console.WriteLine(result);
            }

        }
    }
}
