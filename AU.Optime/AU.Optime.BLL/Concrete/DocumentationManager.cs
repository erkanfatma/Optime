using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class DocumentationManager : IDocumentationService {
            private readonly IDocumentationDal _documenationDal;
            public DocumentationManager(IDocumentationDal documentationDal) => _documenationDal = documentationDal;
            //To add new object
            public void AddDocumentation(Documentation documentation) {
                  documentation.RegisterTime = DateTime.Now;
                  _documenationDal.Add(documentation);
            }

            //To delete selected object
            public void DeleteDocumentation(Documentation documentation) {
                  _documenationDal.Delete(documentation);
            }
            //To get one object with its id
            public Documentation GetDocumentation(int? id) => _documenationDal.Get(c => c.DocumentationId == id);

            //To list all object
            public List<Documentation> GetDocumentations() => _documenationDal.GetAll();

            //for tasks and projects, 
            //To list objects depend on projectid or task id
            public List<Documentation> GetDocumentsById(int? id, bool isProject) {
                  if(id is null) {
                        throw new ArgumentNullException(nameof(id));
                  }
                  return _documenationDal.GetAll(x => x.RelationId == id && x.IsProject == isProject);

            }

            //To update selected object
            public void UpdateDocumentation(Documentation documentation) => _documenationDal.Update(documentation);
      }
}
