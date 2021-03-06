﻿using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int Id);
        void Add(Car car);
        void Delete(Car car);

        void Update(Car car);

        List<Car> GetCarsByBrandId(int brandId);

        List<Car> GetCarsByColorId(int colorID);

        List<CarDetailsDto> GetCarDetails();
    }
}
