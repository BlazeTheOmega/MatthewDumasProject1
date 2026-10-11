using System;
using System.Collections.Generic;

namespace MatthewDumasProject1.Model
{
    public class CarLot
    {
        // Private inventory list
        private readonly List<Car> inventory;

        // Sales tax rate of 7.8%
        public const decimal TaxRate = 0.078m;

        // Default constructor
        public CarLot()
        {
            inventory = new List<Car>();
            StockLotWithDefaultInventory();
        }

        // Add the four default vehicles
        private void StockLotWithDefaultInventory()
        {
            inventory.Add(new Car("Ford", "Focus ST",
                28.3, 26298.98m));

            inventory.Add(new Car("Chevrolet", "Camaro ZL1",
                19.0, 65401.23m));

            inventory.Add(new Car("Honda", "Accord Sedan EX",
                30.2, 26780.00m));

            inventory.Add(new Car("Lexus", "ES 350",
                24.1, 42101.10m));
        }

        // Find all cars matching a make
        public List<Car>? FindCarsByMake(string make)
        {
            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException(
                    "Make cannot be empty.", nameof(make));
            }

            List<Car> matchingCars = new List<Car>();

            foreach (Car car in inventory)
            {
                if (string.Equals(car.Make, make,
                    StringComparison.OrdinalIgnoreCase))
                {
                    matchingCars.Add(car);
                }
            }

            return matchingCars.Count > 0
                ? matchingCars : null;
        }

        // Find a car by make and model
        public Car? FindCarByMakeModel(string make, string model)
        {
            if (string.IsNullOrWhiteSpace(make))
            {
                throw new ArgumentException(
                    "Make cannot be empty.", nameof(make));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(
                    "Model cannot be empty.", nameof(model));
            }

            foreach (Car car in inventory)
            {
                bool makeMatches = string.Equals(
                    car.Make, make,
                    StringComparison.OrdinalIgnoreCase);

                bool modelMatches = string.Equals(
                    car.Model, model,
                    StringComparison.OrdinalIgnoreCase);

                if (makeMatches && modelMatches)
                {
                    return car;
                }
            }

            return null;
        }

        // Purchase and remove a car from inventory
        public Car? PurchaseCar(string make, string model)
        {
            if (string.IsNullOrWhiteSpace(make) ||
                string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException(
                    "Make and model cannot be empty.");
            }

            Car? car = FindCarByMakeModel(make, model);

            if (car != null)
            {
                inventory.Remove(car);
            }

            return car;
        }

        // Add a new car to inventory
        public void AddCar(string make, string model,
            double mpg, decimal price)
        {
            Car newCar = new Car(make, model, mpg, price);
            inventory.Add(newCar);
        }

        // Calculate purchase price including sales tax
        public decimal GetTotalCostOfPurchase(Car car)
        {
            ArgumentNullException.ThrowIfNull(car);

            return car.Price * (1 + TaxRate);
        }

        // Find the least expensive car
        public Car? FindLeastExpensiveCar()
        {
            if (inventory.Count == 0)
            {
                return null;
            }

            Car cheapestCar = inventory[0];

            foreach (Car car in inventory)
            {
                if (car.Price < cheapestCar.Price)
                {
                    cheapestCar = car;
                }
            }

            return cheapestCar;
        }

        // Find the most expensive car
        public Car? FindMostExpensiveCar()
        {
            if (inventory.Count == 0)
            {
                return null;
            }

            Car mostExpensiveCar = inventory[0];

            foreach (Car car in inventory)
            {
                if (car.Price > mostExpensiveCar.Price)
                {
                    mostExpensiveCar = car;
                }
            }

            return mostExpensiveCar;
        }

        // Find the car with the best MPG
        public Car? FindBestMPGCar()
        {
            if (inventory.Count == 0)
            {
                return null;
            }

            Car bestCar = inventory[0];

            foreach (Car car in inventory)
            {
                if (car.Mpg > bestCar.Mpg)
                {
                    bestCar = car;
                }
            }

            return bestCar;
        }

        // Find the car with the worst MPG
        public Car? FindWorstMPG()
        {
            if (inventory.Count == 0)
            {
                return null;
            }

            Car worstCar = inventory[0];

            foreach (Car car in inventory)
            {
                if (car.Mpg < worstCar.Mpg)
                {
                    worstCar = car;
                }
            }

            return worstCar;
        }

        // Return the total number of cars
        public int Count => inventory.Count;

        // Return the inventory list
        public List<Car> Inventory => inventory;
    }
}