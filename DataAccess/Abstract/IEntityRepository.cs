﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip
    //Ientity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //IEntity new lenemez çünkü interface. new() yazdık yani new lenebilir olmalı
   public interface IEntityRepository<T> where T:class,IEntity,new() 
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
