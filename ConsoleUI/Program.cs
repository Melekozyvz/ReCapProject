using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        public static void ListAllCars(List<Car> cars)
        {
            Console.WriteLine();
            foreach (var car in cars)
            {
                Console.WriteLine(car.Id + " - " + car.Description + " Brand Id: " + car.BrandId + " Color Id:" + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " TL");
            }
        }
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            //List all Registered Cars
            Console.WriteLine("All Cars In System");
            ListAllCars(carManager.GetAll());
           

            //Add car to System
            var carToAdd = new Car { Id = 8, BrandId = 1, ColorId = 3, DailyPrice = 1578952, Description = "Car To Add 1", ModelYear = 2021 };
            carManager.Add(carToAdd);
            Console.WriteLine("\nResult after add car with Id=8");
            ListAllCars(carManager.GetAll());

            //Update Car
            var carToUpdate = new Car { Id = 1, BrandId = 1, ColorId = 3, DailyPrice = 200000, Description = "Updated car with Id=1", ModelYear = 2020 };
            carManager.Update(carToUpdate);
            Console.WriteLine("\nResult after update car with Id=8");
            ListAllCars(carManager.GetAll());

            //Get Car By Id
            Car carToDelete = carManager.GetById(8);

            //Delete Car 
            carManager.Delete(carToDelete);
            Console.WriteLine("\nResult after delet car with Id=8");
            ListAllCars(carManager.GetAll());

        }


    }
}
