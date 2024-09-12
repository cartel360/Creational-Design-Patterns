using System;

namespace FactoryMethodPattern
{
    // Abstract Product: Vehicle
    public abstract class Vehicle
    {
        public abstract void Drive();
    }

    // Concrete Product: Car
    public class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Driving a car.");
        }
    }

    // Concrete Product: Bike
    public class Bike : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Riding a bike.");
        }
    }

    // Abstract Creator: VehicleFactory
    public abstract class VehicleFactory
    {
        // Factory Method
        public abstract Vehicle CreateVehicle();

        public void AssembleVehicle()
        {
            // The factory method is called to create a vehicle.
            Vehicle vehicle = CreateVehicle();
            Console.WriteLine("Assembling vehicle.");
            vehicle.Drive();
        }
    }

    // Concrete Creator: CarFactory
    public class CarFactory : VehicleFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Car();
        }
    }

    // Concrete Creator: BikeFactory
    public class BikeFactory : VehicleFactory
    {
        public override Vehicle CreateVehicle()
        {
            return new Bike();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a car factory and assemble a car
            VehicleFactory carFactory = new CarFactory();
            carFactory.AssembleVehicle();

            Console.WriteLine();

            // Create a bike factory and assemble a bike
            VehicleFactory bikeFactory = new BikeFactory();
            bikeFactory.AssembleVehicle();
        }
    }
}
