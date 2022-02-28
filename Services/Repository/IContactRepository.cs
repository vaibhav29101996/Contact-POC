using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public interface IContactRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        IEnumerable<T> Insert(IEnumerable<T> entities);
    }
}
