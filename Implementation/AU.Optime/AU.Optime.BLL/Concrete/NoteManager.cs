using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Concrete {

      //Specify operations using Data Access Layer for Note objects
      public class NoteManager : INoteService {
            private readonly INoteDal _noteDal;
            public NoteManager(INoteDal noteDal) => _noteDal = noteDal;
            //To add new object
            public void AddNote(Note note) {
                  note.RegisterTime = DateTime.Now;
                  _noteDal.Add(note);
            }
            //To delete selected object
            public void DeleteNote(Note note) => _noteDal.Delete(note);

            //To get object with its id
            public Note GetNote(int? id) {
                  if(id is null)
                        throw new ArgumentNullException(nameof(id));
                  return _noteDal.Get(c => c.NoteId == id);
            }
            //To list objects depend on userid
            public List<Note> GetNotesByUserId(int? userId) {
                  if(userId is null)
                        throw new ArgumentNullException(nameof(userId));
                  return _noteDal.GetAll(c => c.UserId == userId);
            }
            //To list all object
            public List<Note> GetNotes() => _noteDal.GetAll();
            //To update selected object
            public void UpdateNote(Note note) => _noteDal.Update(note);  
      }
}
