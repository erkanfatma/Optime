using AU.Optime.BLL.Abstract;
using AU.Optime.Entities.Concrete;
using AU.Optime.WebApi.Models;
using AU.Optime.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace AU.Optime.WebApi.Controllers {
      //To build services to reach Documentation objects from mobile devices
      [RoutePrefix("api/docs")]
      public class DocumentationsController : BaseController {
            ApiResult result = new ApiResult();
            private readonly IDocumentationService _documentationService;
            public DocumentationsController(IDocumentationService documentationService) => _documentationService = documentationService;


            [HttpGet, Route("")]
            public ApiResult GetDocumentations() {
                  try {
                        result.Result = true;
                        List<DocumentationViewModel> docs = _documentationService.GetDocumentations().Select(x => new DocumentationViewModel { DocumentationId = x.DocumentationId, DocumentationURL = x.DocumentationURL, IsProject = x.IsProject, RegisterTime = x.RegisterTime, RelationId = x.RelationId }).ToList();
                        result.Data = docs;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("docsbyrelation/{relationId:int}/{isProject:bool}")]
            public ApiResult GetDocsByRelation(int relationId, bool isProject) {
                  try {
                        result.Result = true;
                        List<DocumentationViewModel> docs = _documentationService.GetDocumentsById(relationId, isProject).Select(x => new DocumentationViewModel { DocumentationId = x.DocumentationId, DocumentationURL = x.DocumentationURL, IsProject = x.IsProject, RegisterTime = x.RegisterTime, RelationId = x.RelationId }).ToList();
                        result.Data = docs;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpGet, Route("doc/{id:int}")]
            public ApiResult GetDoc(int id) {
                  try {
                        result.Result = true;
                        var doc = _documentationService.GetDocumentation(id);
                        result.Data = new DocumentationViewModel { DocumentationId = doc.DocumentationId, DocumentationURL = doc.DocumentationURL, IsProject = doc.IsProject, RegisterTime = doc.RegisterTime, RelationId = doc.RelationId };

                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPut, Route("editdoc")]
            public ApiResult PutDoc([FromBody]DocumentationViewModel model) {
                  try {
                        result.Result = true;
                        _documentationService.UpdateDocumentation(new Documentation { DocumentationId = model.DocumentationId, DocumentationURL = model.DocumentationURL, RelationId = model.RelationId, IsProject = model.IsProject });
                        result.Data = "Document updated.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPost, Route("adddoc")]
            public ApiResult PostNote(DocumentationViewModel model) {
                  try {
                        result.Result = true;
                        _documentationService.AddDocumentation(new Documentation { DocumentationId = model.DocumentationId, DocumentationURL = model.DocumentationURL, IsProject = model.IsProject, RelationId = model.RelationId });
                        result.Data = "Document added.";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpDelete, Route("deletedoc/{id:int}")]
            public ApiResult DeleteDoc(int id) {
                  try {
                        result.Result = true;
                        _documentationService.DeleteDocumentation(new Documentation { DocumentationId = id });
                        result.Data = "Document deleted.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

      }
}
