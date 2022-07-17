using Core.Abstract.EntityFramework;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;




namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars

                             join b in context.Brands
                             on c.BrandId equals b.Id

                             join co in context.Colors
                             on c.ColorId equals co.Id

                             select new CarDetailDto()
                             {
                                 CarDescription = c.Description,
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
                             
            }

        }







        

        public Car GetByBrandId(int Id)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return reCapProjectContext.Set<Car>().SingleOrDefault(p => p.BrandId == Id);
            }
        }

        public Car GetByColorId(int Id)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return reCapProjectContext.Set<Car>().SingleOrDefault(p => p.ColorId == Id);

            }
        }

        
    }
}
