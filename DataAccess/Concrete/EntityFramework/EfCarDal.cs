using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                var addedEntity = reCapProjectContext.Entry(car);
                addedEntity.State = EntityState.Added;
                reCapProjectContext.SaveChanges();
            }
        }
        public void Update(Car car)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                var updatedEntity = reCapProjectContext.Entry(car);
                updatedEntity.State = EntityState.Modified;
                reCapProjectContext.SaveChanges();
            }
        }



        public void Delete(Car car)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                var deletedEntity = reCapProjectContext.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectContext.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car,bool>> filter=null)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return filter == null 
                    ? reCapProjectContext.Set<Car>().ToList() 
                    : reCapProjectContext.Set<Car>().Where(filter).ToList() ;
            }
        }

        public Car GetById(int id)
        {
            using (ReCapProjectContext reCapProjectContext = new ReCapProjectContext())
            {
                return reCapProjectContext.Set<Car>().SingleOrDefault(p => p.Id ==id);
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
