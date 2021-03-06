﻿using AU.Optime.Core.DataAccess.EntityFramework;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;

namespace AU.Optime.DAL.Concrete.EntityFramework {
      //To execute CRUD operations depend on Documentation object
      public class EfDocumentationDal : EFEntityRepositoryBase<Documentation, OptimeContext>, IDocumentationDal {
            //specific operations
      }
}
