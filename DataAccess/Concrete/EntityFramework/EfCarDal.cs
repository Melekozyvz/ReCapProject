using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal : EfEntityRepositoryBase<Car,ReCapDbContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailsDto
                             {
                                 CarName=car.Description,BrandName=b.Name,ColorName=color.Name,DailyPrice=car.DailyPrice
                             };
                return result.ToList();
            }
        }
          
            
    }
}
