using System;
using System.Collections.Generic;
using System.Text;

namespace LabCubes.Data
{
   public class UnitOfWork<T> : Repository<T> where T : class
    {
        protected LabCubesDBContext _dataContext;
        public UnitOfWork()
        {
            this._dataContext = new LabCubesDBContext();
            this._context = _dataContext;
            this._dbSet= _dataContext.Set<T>();

        }
        //public UnitOfWork(LabCubesDBContext dataContext)
        //{
        //    //_dataContext = new LabCubesDBContext();
        //    //this._context = _dataContext;
        //    //this._dbSet = _dataContext.Set<T>();
        //}

        public void Commit()
        {
            this._dataContext.SaveChanges();
        }
    }
}
