using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ContactRepository<T> : IContactRepository<T> where T : class
    {
        protected ContactPOCEntities RepositoryContext { get; set; }
        private DbSet<T> _entities;
        public ContactRepository(ContactPOCEntities repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = RepositoryContext.Set<T>();
                return _entities;
            }
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.SaveChanges();
        }
        public void Update(T entity)
        {
          var data=  this.RepositoryContext.Entry(entity);
            data.State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
        // Insert entities       
        public virtual IEnumerable<T> Insert(IEnumerable<T> entities)
        {
            try
            {
                if (Equals(entities, null))
                    throw new ArgumentNullException(nameof(entities));

                this.RepositoryContext.Set<T>().AddRange(entities);
                return entities;
            }
            catch (Exception ex)
            {
                //Remove added entities from objects for all the entities tracked by context.
                Entities.RemoveRange(entities);
                throw;
            }
        }
    }
  
}
