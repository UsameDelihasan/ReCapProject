using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IEntityRepository<T>
    {
        void Add(T car);
        void Update(T car);
        void Delete(T car);
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T GetById(int id);

        T GetByBrandId(int Id);
        T GetByColorId(int Id);
    }
}
