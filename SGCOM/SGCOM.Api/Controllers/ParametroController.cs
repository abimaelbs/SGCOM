using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [RoutePrefix("api/public")]
    public class ParametroController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("parametros")]
        public HttpResponseMessage GetParametros()
        {
            var result = db.Parametros.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("parametros/{parametroId}")]
        public HttpResponseMessage GetParametroById(int parametroId)
        {
            var result = db.Parametros.Where(x => x.Id == parametroId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("parametros")]
        public HttpResponseMessage PostParametros(Parametro parametro)
        {
            if (parametro == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Parametros.Add(parametro);
                db.SaveChanges();

                var result = parametro;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir parametro.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("parametros")]
        public HttpResponseMessage PutParametros(Parametro parametro)
        {
            if (parametro == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Parametro>(parametro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = parametro;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar parametro.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("parametros/{parametroId}")]
        public HttpResponseMessage DeleteParametros(int parametroId)
        {
            if (parametroId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Parametros.Remove(db.Parametros.Find(parametroId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Parametro excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar parametro.");
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
