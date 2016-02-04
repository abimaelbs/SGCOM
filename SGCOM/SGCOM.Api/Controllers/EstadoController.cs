using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;

namespace SGCOM.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class EstadoController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("estados")]
        public HttpResponseMessage GetEstados()
        {
            var result = db.Estados.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("estados/{estadoId}")]
        public HttpResponseMessage GetEstadosById(int estadoId)
        {
            var result = db.Estados.Where(x => x.Id == estadoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("estados")]
        public HttpResponseMessage PostEstados(Estado estado)
        {
            if (estado == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Estados.Add(estado);
                db.SaveChanges();

                var result = estado;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Estado.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("estados")]
        public HttpResponseMessage PutEstados(Estado estado)
        {
            if (estado == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Estado>(estado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = estado;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Estado.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("estados/{estadoId}")]
        public HttpResponseMessage DeleteEstados(int estadoId)
        {
            if (estadoId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Estados.Remove(db.Estados.Find(estadoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Estado excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Estado.");
            }
        }

        #endregion Excluir

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        # endregion Dispose
    }
}