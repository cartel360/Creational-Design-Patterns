using System;

namespace BuilderPattern
{
    // Product: The complex object we are going to build
    public class Car
    {
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public int Wheels { get; set; }
        public bool HasGPS { get; set; }
        public bool HasSunroof { get; set; }

        public void DisplaySpecifications()
        {
            Console.WriteLine($"Engine: {Engine}");
            Console.WriteLine($"Transmission: {Transmission}");
            Console.WriteLine($"Wheels: {Wheels}");
            Console.WriteLine($"GPS: {(HasGPS ? "Yes" : "No")}");
            Console.WriteLine($"Sunroof: {(HasSunroof ? "Yes" : "No")}");
        }
    }

    // Abstract Builder: Defines the steps to create a product
    public abstract class CarBuilder
    {
        protected Car car;

        public void CreateNewCar()
        {
            car = new Car();
        }

        public Car GetCar()
        {
            return car;
        }

        public abstract void SetEngine();
        public abstract void SetTransmission();
        public abstract void SetWheels();
        public abstract void SetGPS();
        public abstract void SetSunroof();
    }

    // Concrete Builder 1: Builds a sports car
    public class SportsCarBuilder : CarBuilder
    {
        public override void SetEngine()
        {
            car.Engine = "V8 Engine";
        }

        public override void SetTransmission()
        {
            car.Transmission = "Manual";
        }

        public override void SetWheels()
        {
            car.Wheels = 4;
        }

        public override void SetGPS()
        {
            car.HasGPS = true;
        }

        public override void SetSunroof()
        {
            car.HasSunroof = true;
        }
    }

    // Concrete Builder 2: Builds an SUV
    public class SUVBuilder : CarBuilder
    {
        public override void SetEngine()
        {
            car.Engine = "V6 Engine";
        }

        public override void SetTransmission()
        {
            car.Transmission = "Automatic";
        }

        public override void SetWheels()
        {
            car.Wheels = 4;
        }

        public override void SetGPS()
        {
            car.HasGPS = true;
        }

        public override void SetSunroof()
        {
            car.HasSunroof = false;
        }
    }

    // Director: Controls the building process
    public class CarDirector
    {
        private CarBuilder _builder;

        public CarDirector(CarBuilder builder)
        {
            _builder = builder;
        }

        // Construct the car by calling the builder's methods step by step
        public void ConstructCar()
        {
            _builder.CreateNewCar();
            _builder.SetEngine();
            _builder.SetTransmission();
            _builder.SetWheels();
            _builder.SetGPS();
            _builder.SetSunroof();
        }

        public Car GetCar()
        {
            return _builder.GetCar();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Building a sports car
            CarBuilder sportsCarBuilder = new SportsCarBuilder();
            CarDirector sportsCarDirector = new CarDirector(sportsCarBuilder);

            sportsCarDirector.ConstructCar();
            Car sportsCar = sportsCarDirector.GetCar();
            Console.WriteLine("Sports Car Specifications:");
            sportsCar.DisplaySpecifications();

            Console.WriteLine();

            // Building an SUV
            CarBuilder suvBuilder = new SUVBuilder();
            CarDirector suvDirector = new CarDirector(suvBuilder);

            suvDirector.ConstructCar();
            Car suv = suvDirector.GetCar();
            Console.WriteLine("SUV Specifications:");
            suv.DisplaySpecifications();
        }
    }
}
