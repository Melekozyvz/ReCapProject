using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car() { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 150000, ModelYear = 2010, Description = "Commercial vehicle" },
            new Car() { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 150000, ModelYear = 2000, Description = "Family vehicle" },
            new Car() { Id = 3, BrandId = 2, ColorId = 5, DailyPrice = 200000, ModelYear = 2015, Description = "Commercial vehicles" },
            new Car() { Id = 4, BrandId = 2, ColorId = 4, DailyPrice = 3000000, ModelYear = 2002, Description = "Family vehicle" },
            new Car() { Id = 5, BrandId = 2, ColorId = 3, DailyPrice = 4000000, ModelYear = 2020, Description = "Family vehicle" },
            new Car() { Id = 6, BrandId = 3, ColorId = 1, DailyPrice = 4580000, ModelYear = 2008, Description = "Commercial vehicle" },
            new Car() { Id = 7, BrandId = 3, ColorId = 2, DailyPrice = 7586000, ModelYear = 2010, Description = "Commercial vehicle" } 
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> getAll()
        {
            return _cars;
        }

        public List<Car> getAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
           return _cars.SingleOrDefault(p=>p.Id==Id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
