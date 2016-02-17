using SGCOM.Data.DataContexts;
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
    public class FornecedorController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("fornecedores")]
        public HttpResponseMessage GetFornecedores()
        {
            var result = db.Fornecedores.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }

        [HttpGet]
        [Route("fornecedores/{fornecedorId}")]
        public HttpResponseMessage GetFornecedorById(int fornecedorId)
        {
            var result = db.Fornecedores.Where(x => x.Id == fornecedorId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("fornecedores")]
        public HttpResponseMessage PostFornecedores(Fornecedor fornecedor)
        {
            if (fornecedor == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Fornecedores.Add(fornecedor);
                db.SaveChanges();

                var result = fornecedor;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir fornecedor.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("fornecedores")]
        public HttpResponseMessage PutFornecedores(Fornecedor fornecedor)
        {
            if (fornecedor == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Fornecedor>(fornecedor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = fornecedor;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar fornecedor.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("fornecedores/{fornecedorId}")]
        public HttpResponseMessage DeleteFornecedores(int fornecedorId)
        {
            if (fornecedorId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Fornecedores.Remove(db.Fornecedores.Find(fornecedorId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Fornecedor excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Fornecedor.");
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
