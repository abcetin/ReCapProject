using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Manager
{
    public class ManagerBaseService<TEntity> 
        where TEntity : class, IEntity, new()

    {

        //public List<TEntity> GetAll()
        //{
        //    return _dal.GetAll();
        //}
        //public void Add(TEntity entity)
        //{


        //    _dal.Add(entity);

        //}



        //public void Update(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(TEntity entity)
        //{
        //    _dal.Delete(entity);
        //}

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
