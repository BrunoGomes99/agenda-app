using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        TEntity CreateWRet(TEntity entity);
        void CreateRange(List<TEntity> entities);
        void UpdateRange(List<TEntity> entities);
        void Update(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        void Delete(TEntity entity);
        public void SaveChanges();
        void Desatachar(TEntity entity);
        void ExecuteDeleteSql(string comando);
    }
}
