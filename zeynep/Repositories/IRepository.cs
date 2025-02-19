﻿using System.Linq.Expressions;

namespace zeynep.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();   
        T Get(Expression<Func<T, bool>> filtre);
        void Ekle(T entity);
        void Sil(T entity);
        void SilAralik(IEnumerable<T> entities);
    }
}
