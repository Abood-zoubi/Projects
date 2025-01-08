using System;

namespace calculator
{
    class Calculator
    {
        private double X { get; set; }
        private double Y { get; set; }

        public Calculator()
        {
           X = 0;
           Y = 0; 
        }

        public Calculator(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Add()
        {
            return X+Y;
        }
        public double Subtract()
        {
            return X-Y;
        }

        public double Multiply()
        {
            return X*Y;
        }
        public double Divide()
        {
            if(Y==0)
            {
                Console.WriteLine("Can not Divide {0} by zero", X);
                return double.NaN;
            }
            else
            {
                return (double) X/Y;
            }
        }
    }


class Program
{
    static void Main(string[] args)
    {
        bool Continue = true;
        
        while(Continue)
        {
            try
            {
                Console.WriteLine("Input Value X: ");
                int x = int.Parse(Console.ReadLine());
    
                Console.WriteLine("Input Value Y: ");
                int y = int.Parse(Console.ReadLine());
    
                Calculator obj1 = new Calculator(x, y);
                Console.WriteLine($"Sum of {x} and {y} is {obj1.Add()}");
                Console.WriteLine($"Subtraction of {x} and {y} is {obj1.Subtract()}");
                Console.WriteLine($"Multiplication of {x} and {y} is {obj1.Multiply()}");
                Console.WriteLine($"Division of {x} and {y} is {obj1.Divide()}");
    
                Console.WriteLine("\nWould you like to perform another calculation? (yes/no)");
                string response = Console.ReadLine().ToLower();
                if(response == "no")
                {
                    Continue = false;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values.");
            }
        }
    }
}
}