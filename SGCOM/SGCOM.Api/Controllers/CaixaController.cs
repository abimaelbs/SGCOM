using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;

namespace SGCOM.Api.Controllers
{
    [MyCorsPolicy]
    [RoutePrefix("api/public")]
    public class CaixaController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("caixas")]
        public HttpResponseMessage GetCaixas()
        {
            var result = db.Caixas.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("caixas/{caixaId}")]
        public HttpResponseMessage GetCAixasById(int caixaId)
        {
            var result = db.Caixas.Where(x => x.Id == caixaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion Filtros

        #region Inserir
        [HttpPost]
        [Route("caixas")]
        public HttpResponseMessage PostCaixas(Caixa caixa)
        {
            if (caixa == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Caixas.Add(caixa);
                db.SaveChanges();

                var result = caixa;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir caixa.");
            }
        }
        #endregion Inserir

        #region Update
        [HttpPut]
        [Route("caixas")]
        public HttpResponseMessage PutCaixas(Caixa caixa)
        {
            if (caixa == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Caixa>(caixa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = caixa;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar caixa.");
            }
        }
        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("caixas/{caixaId}")]
        public HttpResponseMessage DeleteCaixas(int caixaId)
        {
            if (caixaId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Caixas.Remove(db.Caixas.Find(caixaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Caixa excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar caixa.");
            }
        }

        #endregion Excluir

        #region Dispose

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }

        #endregion Dispose
    }
}