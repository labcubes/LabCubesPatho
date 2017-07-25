using System;
using System.Linq;
using System.Linq.Expressions;

namespace LabCubes.Data
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity, bool isDeleted = false);
        void Delete(T entity);
        void DeleteById(int[] ids);
        bool DeleteById(int id);
    }
}
