using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Abstract.EntityFramework
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void Add(T car);
        void Update(T car);
        void Delete(T car);
        List<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);

    }
}
