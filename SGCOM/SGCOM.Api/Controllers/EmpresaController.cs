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
    public class EmpresaController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("empresas")]
        public HttpResponseMessage GetEmpresas()
        {
            var result = db.Empresas.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }

        [HttpGet]
        [Route("empresas/{empresaId}")]
        public HttpResponseMessage GetEmpresaById(int empresaId)
        {
            var result = db.Empresas.Where(x => x.Id == empresaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("empresas")]
        public HttpResponseMessage PostEmpresas(Empresa empresas)
        {
            if (empresas == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Empresas.Add(empresas);
                db.SaveChanges();

                var result = empresas;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir empresa.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("empresas")]
        public HttpResponseMessage PutEmpresas(Empresa empresa)
        {
            if (empresa == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Empresa>(empresa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = empresa;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar empresa.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("empresas/{empresaId}")]
        public HttpResponseMessage DeleteEmpresas(int empresaId)
        {
            if (empresaId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Empresas.Remove(db.Empresas.Find(empresaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Empresa excluída");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar empresa.");
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
