using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace classes
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Customer GetById(int id);
        List<TEntity> GetAll();
    }
}
