using System;
using System.IO;

class Program
{
    delegate int MathOperation(int a, int b);
    delegate void ProcessData(string data);
    static int Add(int x, int y)
    {
        return x + y;
    }

    static void Main()
    {
        MathOperation operation = new MathOperation(Add);

        int result = operation(10, 20);

        Console.WriteLine("The sum is: " + result);

        try
        {
            Fan fan = new Fan();
            fan.Power = 900;
            fan.TurnOn();

            AirConditioner ac = new AirConditioner();
            ac.Power = 1200;  
            ac.TurnOn();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Employee emp = new Employee();
            emp.Name = "John Doe";
            emp.Age = 12; 
            emp.Salary = -5000;  
            emp.DisplayDetails();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Employee emp2 = new Employee();
            emp2.Name = "Jane Smith";
            emp2.Age = 8;
            emp2.Salary = 3000;
            emp2.DisplayDetails();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        ProcessData processData = DisplayData;
        processData += LogData;
        processData("Processing this data...");

        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(10, 20);

        circle.CalculateArea();
        rectangle.CalculateArea();

        Console.WriteLine($"Circle area: {circle.GetArea()}");
        Console.WriteLine($"Rectangle area: {rectangle.GetArea()}");
        Console.ReadLine();
    }

    abstract class Appliance
    {
        private int power;
        public int Power
        {
            get { return power; }
            set
            {
                if (value > 1000)
                    throw new ArgumentException("Power cannot exceed 1000 watts.");
                power = value;
            }
        }
        public abstract void TurnOn();
    }

    class Fan : Appliance
    {
        public override void TurnOn()
        {
            Console.WriteLine($"Fan is turned on with power {Power} watts.");
        }
    }

    class AirConditioner : Appliance
    {
        public override void TurnOn()
        {
            Console.WriteLine($"Air Conditioner is turned on with power {Power} watts.");
        }
    }

    class Person
    {
        private int age;
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Age must be between 0 and 10.");
                age = value;
            }
        }
    }

    class Employee : Person
    {
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative.");
                salary = value;
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Salary: {Salary}");
        }
    }

    static void DisplayData(string data)
    {
        Console.WriteLine("Displaying data: " + data);
    }

    static void LogData(string data)
    {
        string filePath = "log.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Logging data: " + data);
        }
        Console.WriteLine("Data has been logged to file: " + filePath);
    }

    abstract class Shape
    {
        protected double Area { get; set; }

        public abstract void CalculateArea();

        public double GetArea()
        {
            return Area;
        }
    }

    class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override void CalculateArea()
        {
            Area = Math.PI * radius * radius;
        }
    }

    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override void CalculateArea()
        {
            Area = length * width;
        }
    }
}