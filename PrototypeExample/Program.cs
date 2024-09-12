using System;

namespace PrototypePattern
{
    // Prototype interface
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string Color { get; set; }

        // Abstract method to clone the object
        public abstract Vehicle Clone();

        public void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {this.GetType().Name}, Model: {Model}, Color: {Color}");
        }
    }

    // Concrete Prototype 1: Car
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string model, string color, int numberOfDoors)
        {
            Model = model;
            Color = color;
            NumberOfDoors = numberOfDoors;
        }

        // Clone method to return a copy of the Car object
        public override Vehicle Clone()
        {
            Console.WriteLine("Cloning Car...");
            return (Vehicle)this.MemberwiseClone(); // Shallow copy
        }
    }

    // Concrete Prototype 2: Bike
    public class Bike : Vehicle
    {
        public bool HasCarrier { get; set; }

        public Bike(string model, string color, bool hasCarrier)
        {
            Model = model;
            Color = color;
            HasCarrier = hasCarrier;
        }

        // Clone method to return a copy of the Bike object
        public override Vehicle Clone()
        {
            Console.WriteLine("Cloning Bike...");
            return (Vehicle)this.MemberwiseClone(); // Shallow copy
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Original Car object
            Car originalCar = new Car("Sedan", "Red", 4);
            originalCar.DisplayInfo();

            // Clone the Car object
            Car clonedCar = (Car)originalCar.Clone();
            clonedCar.DisplayInfo();

            Console.WriteLine();

            // Original Bike object
            Bike originalBike = new Bike("Mountain Bike", "Blue", true);
            originalBike.DisplayInfo();

            // Clone the Bike object
            Bike clonedBike = (Bike)originalBike.Clone();
            clonedBike.DisplayInfo();
        }
    }
}
