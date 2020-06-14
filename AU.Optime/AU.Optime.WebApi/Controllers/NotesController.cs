using AU.Optime.BLL.Abstract;
using AU.Optime.Entities.Concrete;
using AU.Optime.WebApi.Models;
using AU.Optime.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AU.Optime.WebApi.Controllers {

      //To build services to reach Note objects from mobile devices
      [RoutePrefix("api/notes")]
      public class NotesController : BaseController {
            ApiResult result = new ApiResult();
            private readonly INoteService _noteService;
            public NotesController(INoteService noteService) => _noteService = noteService;

            // GET: api/Notes
            [HttpGet, Route("")]
            public ApiResult GetNotes() {
                  try {
                        result.Result = true;
                        List<NoteViewModel> notes = _noteService.GetNotes().Select(c => new NoteViewModel { Description = c.Description, IsImportant = c.IsImportant, NoteId = c.NoteId, RegisterTime = c.RegisterTime, UserId = c.UserId }).ToList();
                        result.Data = notes;
                        result.Message = "Success.";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;

            }

            [HttpGet, Route("getnotesbyuser/{userId:int}")]
            public ApiResult GetNotesByUser(int userId) {
                  try {
                        result.Result = true;
                        List<NoteViewModel> notes = _noteService.GetNotesByUserId(userId).Select(c => new NoteViewModel { Description = c.Description, IsImportant = c.IsImportant, NoteId = c.NoteId, RegisterTime = c.RegisterTime, UserId = c.UserId }).ToList();
                        result.Data = notes;
                        result.Message = "Success.";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }


            // GET: api/Notes/5
            [HttpGet, Route("note/{id:int}")]
            public ApiResult GetNote(int id) {
                  try {
                        result.Result = true;
                        var note = _noteService.GetNote(id);
                        result.Data = new NoteViewModel() { Description = note.Description, IsImportant = note.IsImportant, NoteId = note.NoteId, RegisterTime = note.RegisterTime, UserId = note.UserId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;

            }

            // PUT: api/Notes/5
            [HttpPut, Route("editnote")]
            public ApiResult PutNote([FromBody]NoteViewModel model) {
                  try {
                        result.Result = true;
                        _noteService.UpdateNote(new Note { Description = model.Description, IsImportant = model.IsImportant, NoteId = model.NoteId, UserId = model.UserId });
                        var note = _noteService.GetNote(model.NoteId);
                        result.Data = new NoteViewModel { NoteId = model.NoteId, Description = model.Description, IsImportant = model.IsImportant, RegisterTime = model.RegisterTime, UserId = model.UserId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;


            }

            // POST: api/Notes
            [HttpPost, Route("addnote")]
            public ApiResult PostNote(NoteViewModel model) {
                  try {
                        result.Result = true;
                        var newNote = new Note { Description = model.Description, IsImportant = model.IsImportant, UserId = model.UserId };
                        _noteService.AddNote(newNote);
                        result.Data = new NoteViewModel { NoteId = newNote.NoteId, Description = newNote.Description, IsImportant = newNote.IsImportant, RegisterTime = newNote.RegisterTime, UserId = newNote.UserId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            // DELETE: api/Notes/5
            [HttpDelete, Route("deletenote/{id:int}")]
            public ApiResult DeleteNote(int id) {
                  try {
                        result.Result = true;
                        _noteService.DeleteNote(new Note() { NoteId = id });
                        result.Data = "Note deleted.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

      }
}
