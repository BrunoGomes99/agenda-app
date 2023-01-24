using AgendaApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Repository.Implementations
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected MyDbContext _context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(MyDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return this._context.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity CreateWRet(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public void CreateRange(List<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Desatachar(TEntity entity)
        {
            var teste = _context.Entry(entity);
            teste.State = EntityState.Detached;
            SaveChanges();
        }

        public void ExecuteDeleteSql(string comando)
        {
            _context.Database.ExecuteSqlRaw(comando);
        }
    }
}
