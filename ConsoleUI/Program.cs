using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            Console.WriteLine("Added Cars:");
            foreach (var car in cars)
            {
                Console.WriteLine(car.Id + " - Description: " + car.Description + " Brand Id: " + car.BrandId + " Color Id:" + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " TL");
            }
        }
        static void Main(string[] args)
        {
            //Brands CRUD Operations
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandsCRUDOP(brandManager);

            //Colors CRUD Operations
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorCRUDOP(colorManager);

            //Cars CRUD Operations
            CarManager carManager = new CarManager(new EfCarDal());
            CarCRUDOP(carManager);
        }
        public static void ColorCRUDOP(ColorManager colorManager)
        {
            colorManager.Add(new Color() { Id = 1, Name = "Black" });
            colorManager.Add(new Color() { Id = 2, Name = "Blue" });
            colorManager.Add(new Color() { Id = 3, Name = "Gray" });

            Console.WriteLine("All Colors:");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            Color colorToUpdate = colorManager.GetById(3);
            Console.WriteLine("Color getById: "+ colorToUpdate.Name);
            colorToUpdate.Name = "White";
            colorManager.Update(colorToUpdate);

            Console.WriteLine("All Colors:");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            colorManager.Delete(colorToUpdate);
            Console.WriteLine("All Colors:");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            
        }
        public static void CarCRUDOP(CarManager carManager)
        {
            carManager.Add(new Car() { Id = 1, BrandId = 2, ColorId = 1, DailyPrice = 300000, Description = "Temiz Nissan Hasarsız.", ModelYear = 2001 });
            carManager.Add(new Car() { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 34586, Description = "Temiz Hasarsız sağ çamurluk değişen.", ModelYear = 2005 });
            carManager.Add(new Car() { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 54200, Description = "Hasar kaydı yok.", ModelYear = 2004 });
            carManager.Add(new Car() { Id = 4, BrandId = 1, ColorId = 3, DailyPrice = 364000, Description = "Öğretmenden temiz araç.", ModelYear = 2004 });
            carManager.Add(new Car() { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 55000, Description = "Temiz Hasarsız.", ModelYear = 2002 });
            carManager.Add(new Car() { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 275220, Description = "Temiz Hasarsız.", ModelYear = 2010 });
            carManager.Add(new Car() { Id = 7, BrandId = 5, ColorId = 3, DailyPrice = 450000, Description = "Sıfır.", ModelYear = 2018 });

            ListAllCars(carManager.GetAll());

            Car carToUpdate = carManager.GetById(6);

            carToUpdate.DailyPrice = 270000;
            carToUpdate.BrandId = 1;
            carToUpdate.Description = "Km si düşük temiz aile arabası.";
            carManager.Update(carToUpdate);

            ListAllCars(carManager.GetAll());
            Car carTodelete = carManager.GetById(3);
            carManager.Delete(carTodelete);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }
        public static void BrandsCRUDOP(BrandManager brandManager)
        {
            //CRUD Brand
            brandManager.Add(new Brand() { Id = 1, Name = "Mercedes" });
            brandManager.Add(new Brand() { Id = 2, Name = "Nissan" });
            brandManager.Add(new Brand() { Id = 3, Name = "Kia" });
            brandManager.Add(new Brand() { Id = 4, Name = "Citroen" });
            brandManager.Add(new Brand() { Id = 5, Name = "Peugeot" });

            Console.WriteLine("Brands:");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Brand brandToUpdate = brandManager.GetById(4);
            brandToUpdate.Name = "BMW";
            brandManager.Update(brandToUpdate);

            Console.WriteLine();
            Console.WriteLine("Brands:");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Brand brandToDelete = brandManager.GetById(5);
            brandManager.Delete(brandToDelete);

            Console.WriteLine();
            Console.WriteLine("Brands:");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
    }
}
