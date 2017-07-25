using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LabCubes.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected LabCubesDBContext DataContext;
        protected DbSet<T> dbSet;
        public LabCubesDBContext _context
        {
            get
            {
                return this.DataContext;
            }
            set
            {
                this.DataContext = value;
            }
        }
        public DbSet<T> _dbSet
        {
            get
            {
                return this.dbSet;
            }
            set
            {
                this.dbSet = value;
            }
        }

        #region Constructor and Destructors
        public Repository()
        {
           // DataContext = new LabCubesDBContext(); //_context;
           // _dbSet = DataContext.Set<T>();
        }
        
        #endregion

        #region IRepository<T> Members
        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity"> Entity to be added</param>
        public T Insert(T entity)
        {
            try
            {
               // DataContext.Add(entity);
                _dbSet.Add(entity);
            }
            catch(Exception ex)
            {

            }
            return entity;
        }

        /// <summary>
        /// Return a queryable collection on the basis of the passed filter criteria
        /// </summary>
        /// <param name="predicate">Filter criteria</param>
        /// <returns>Returns the filtered collection</returns>
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// Returns all the instance of the entity
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Gets an entity by its id
        /// </summary>
        /// <param name="id">Id of the object to be retrieved</param>
        /// <returns>Returns the selected entity</returns>
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Saves data to database
        /// </summary>
        public virtual void Update(T entity, bool isDeleted = false)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = DataContext.Entry<T>(entity);

            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                object pkey;

                if (entity.GetType().GetProperty("Id") != null)
                {
                    pkey = entity.GetType().GetProperty("Id").GetValue(entity);
                }
                else
                {
                    pkey = entity.GetType().GetProperty("ID").GetValue(entity);
                }

                var set = DataContext.Set<T>();
                T attachedEntity = _dbSet.Find(pkey); // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = DataContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
                //DataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Saves data to database
        /// </summary>
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = DataContext.Entry<T>(entity);

            object pkey;

            if (entity.GetType().GetProperty("Id") != null)
            {
                pkey = entity.GetType().GetProperty("Id").GetValue(entity);
            }
            else
            {
                pkey = entity.GetType().GetProperty("ID").GetValue(entity);
            }

            var set = DataContext.Set<T>();
            set.Remove(entity);
            entry.State = EntityState.Deleted; // This should attach entity                
            //DataContext.SaveChanges();
        }

        /// <summary>
        /// Delete Enity Record by Id's
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteById(int[] ids)
        {
            foreach (var id in ids)
            {
                var entity = _dbSet.Find(id);

                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    //DataContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete Enity Record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                //DataContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}