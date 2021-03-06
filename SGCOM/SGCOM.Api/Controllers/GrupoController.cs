﻿using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [MyCorsPolicy]
    [RoutePrefix("api/public")]
    public class GrupoController : ApiController
    {
        #region Objeto Conexão

        private SGCOMDataContext db = new SGCOMDataContext();

        #endregion

        #region Filtros

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

        #endregion

        #region Adicionar
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

        #endregion

        #region Updates
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }
        
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }

        #endregion

        #region Excluir
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
                                
                return Request.CreateResponse(HttpStatusCode.OK, "Grupo excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar grupo.");
            }
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {                        
            db.Dispose();            
            base.Dispose(disposing);
        }

        #endregion
    }
}