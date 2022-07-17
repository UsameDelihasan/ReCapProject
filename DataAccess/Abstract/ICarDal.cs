using Core.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {       
         Car GetByBrandId(int id);
         Car GetByColorId(int id);
        List<CarDetailDto> GetCarDetails();
    }
}
