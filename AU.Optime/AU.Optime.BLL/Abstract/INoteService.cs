using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {

      //To specify operations that connect different layer for Note objects
      public interface INoteService {
            //To get object with its id
            Note GetNote(int? id);
            //To list all object
            List<Note> GetNotes();
            //To list objects depend on userid
            List<Note> GetNotesByUserId(int? userId);
            //To add new object
            void AddNote(Note note);
            //To update selected object
            void UpdateNote(Note note);
            //To delete selected object
            void DeleteNote(Note note);
      }

}
