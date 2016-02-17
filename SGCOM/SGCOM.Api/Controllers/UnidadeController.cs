using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [MyCorsPolicy]
    [RoutePrefix("api/public")]
    public class UnidadeController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("unidades")]
        public HttpResponseMessage GetUnidades()
        {
            var result = db.Unidades.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("unidades/{unidadeId}")]
        public HttpResponseMessage GetUnidadeById(int unidadeId)
        {
            var result = db.Unidades.Where(x => x.Id == unidadeId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("unidades")]
        public HttpResponseMessage PostUnidades(Unidade unidade)
        {
            if (unidade == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Unidades.Add(unidade);
                db.SaveChanges();

                var result = unidade;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Unidade.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("unidades")]
        public HttpResponseMessage PutUnidades(Unidade unidade)
        {
            if (unidade == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Unidade>(unidade).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = unidade;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Unidade.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("unidades/{unidadeId}")]
        public HttpResponseMessage DeleteUnidades(int unidadeId)
        {
            if (unidadeId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Unidades.Remove(db.Unidades.Find(unidadeId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Unidade excluída");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Unidade.");
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
