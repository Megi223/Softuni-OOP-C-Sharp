using System;
using System.Collections.Generic;
using System.Text;

namespace P01ClassBoxData
{
    public class Box
    {
        private double height;
        private double width;
        private double length;


        public Box(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Height 
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    
                    //Console.WriteLine("Height cannot be zero or negative.");
                    throw new ArgumentException("Height cannot be zero or negative.");

                }
                this.height = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    //Console.WriteLine("Width cannot be zero or negative.");
                    throw new ArgumentException("Width cannot be zero or negative.");
                    
                }
                this.width = value;
            }
        }
        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    
                   //Console.WriteLine("Length cannot be zero or negative.");
                    throw new Exception("Length cannot be zero or negative.");
                    
                }
                this.length = value;
            }
        }

        public string GetSurfaceArea()
        {
            double result = 2 * this.Length * this.Width + 2 * this.Width * this.Height + 2 * this.Length * this.Height;
            return String.Format("{0:0.00}", result);
        }
        public string GetLateralSurfaceArea()
        {
            double result =  2 * this.Width * this.Height + 2 * this.Length * this.Height;
            return String.Format("{0:0.00}", result);
        }
        public string GetVolume()
        {
            double result = this.Height * this.Length * this.Width;
            return String.Format("{0:0.00}", result);

        }
    }
}
