using AU.Optime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AU.Optime.Core.DataAccess {
      
      //To create a generic skeleton which run with all database table objects. Generic structure use T.
      //Where all basic operations are defined.
      public interface IEntityRepository<T> where T : class, IEntity, new() {

            //Return one object. It return specificed typed. So, it begins with T.  To filter object, Expression structure is used.
            T Get(Expression<Func<T, bool>> filter = null);
            
            // To return all objects which is type of specified. To filter these objects, Expression structure is used.
            List<T> GetAll(Expression<Func<T, bool>> filter = null);
            
            //Used for creating an object. It returns nothing
            void Add(T entity);
            
            //To update object. It returns nothing
            void Update(T entity);
            
            //To delete an object. It deletes with object id
            void Delete(T entity);
      }
}
