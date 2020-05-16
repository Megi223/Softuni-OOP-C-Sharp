using System;

namespace P01ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                var box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.GetSurfaceArea()}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea()}");
                Console.WriteLine($"Volume - {box.GetVolume()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return;
            }
            

            


        }
    }
}
