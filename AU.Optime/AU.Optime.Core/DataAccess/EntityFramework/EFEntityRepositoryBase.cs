using AU.Optime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Core.DataAccess.EntityFramework {
      
      //Base repository for Entity Framework(EF)
      //EF needs 2 attribute, 1-> Context, 2 -> Entity
      public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new() {

            //To add any object which is specified type
            public void Add(TEntity entity) {
                  using(var context = new TContext()) {
                        var createdEntity = context.Entry(entity);
                        createdEntity.State = EntityState.Added;
                        context.SaveChanges();
                  }
            }

            //To delete any object
            public void Delete(TEntity entity) {
                  using(var context = new TContext()) {
                        var removed = context.Entry(entity);
                        removed.State = EntityState.Deleted;
                        context.SaveChanges();
                  }
            }

            //To delete any object
            public TEntity Get(Expression<Func<TEntity, bool>> filter = null) {
                  using(var context = new TContext()) {
                        return context.Set<TEntity>().SingleOrDefault(filter);
                  }
            }

            //To get all objects in the entity
            public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) {
                  using(var context = new TContext()) {
                        return filter == null
                            ? context.Set<TEntity>().ToList()
                            : context.Set<TEntity>().Where(filter).ToList();
                  }
            }

            //To edit object
            public void Update(TEntity entity) {
                  using(var context = new TContext()) {
                        var updated = context.Entry(entity);
                        updated.State = EntityState.Modified;
                        context.SaveChanges();
                  }
            }
      }
}
