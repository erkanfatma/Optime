using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers for Document object
      public interface IDocumentationService {
            //To get one object with its id
            Documentation GetDocumentation(int? id);
            //To list all object
            List<Documentation> GetDocumentations();

            //for tasks and projects, 
            //To list objects depend on projectid or task id
            List<Documentation> GetDocumentsById(int? id, bool isProject);
            //To add new object
            void AddDocumentation(Documentation documentation);
            //To update selected object
            void UpdateDocumentation(Documentation documentation);
            //To delete selected object
            void DeleteDocumentation(Documentation documentation);
      }
}
 