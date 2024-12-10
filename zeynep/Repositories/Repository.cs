using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using zeynep.Models;

namespace zeynep.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            this.dbSet = _appDbContext.Set<T>();
        }
        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filtre)
        {
            IQueryable<T> sorgu = dbSet;
            sorgu = sorgu.Where(filtre);
            return sorgu.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> sorgu = dbSet;
            return sorgu.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }

        public void SilAralik(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }

}
