using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else Console.WriteLine("Araba Eklenemedi.");
           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.getAll();
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(p=>p.Id==Id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.getAll(p=>p.BrandId==brandId);
        }

        public List<Car> GetCarsByColorId(int colorID)
        {
            return _carDal.getAll(p => p.ColorId == colorID);
        }

        public void Update(Car car)
        {
     
            _carDal.Update(car);
        }
       
    }
}
