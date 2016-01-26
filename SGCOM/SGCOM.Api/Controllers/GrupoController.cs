using SGCOM.Domain;
using SGCOM.Infra.DataContexts;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class GrupoController : ApiController
    {
        private SGComDataContext db = new SGComDataContext();

        [HttpGet]
        [Route("grupos")]
        public HttpResponseMessage GetGrupos()
        {
            var result = db.Grupos.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("grupos/{grupoId}")]
        public HttpResponseMessage GetGruposById(int grupoId)
        {
            var result = db.Grupos.Where(x => x.Id == grupoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("grupos")]
        public HttpResponseMessage PostGrupos(Grupo grupo)
        {
            if (grupo == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Grupos.Add(grupo);
                db.SaveChanges();

                var result = grupo;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Falha ao incluir grupo.");
            }            
        }

        //Update
        [HttpPatch]
        [Route("grupos")]
        public HttpResponseMessage PatchGrupo(Grupo grupo)
        {
            if (grupo == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Grupo>(grupo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = grupo;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }

        //Update
        [HttpPut]
        [Route("grupos")]
        public HttpResponseMessage PutGrupo(Grupo grupo)
        {
            if (grupo == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Grupo>(grupo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = grupo;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }

        //Update
        [HttpDelete]
        [Route("grupos/{grupoId}")]
        public HttpResponseMessage DeleteGrupo(int grupoId)
        {
            if (grupoId < 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Grupos.Remove(db.Grupos.Find(grupoId));
                db.SaveChanges();
                                
                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }

        protected override void Dispose(bool disposing)
        {                        
            db.Dispose();            
            base.Dispose(disposing);
        }       
    }
}