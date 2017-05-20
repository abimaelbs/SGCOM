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
    public class Produto2Controller : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Read

        [HttpGet]
        [Route("produtos2")]
        public HttpResponseMessage GetProdutos()
        {
            var result = db.Produto2s.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("produto2/{produtoId}")]
        public HttpResponseMessage GetProdutoById(int produtoId)
        {
            var result = db.Produto2s.Where(x => x.Id == produtoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion Read

        #region Write

        [HttpPost]
        [Route("produto2")]
        public HttpResponseMessage PostProdutos(Produto2 produto)
        {
            if (produto == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produto2s.Add(produto);
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Produto.");
            }
        }

        [HttpPut]
        [Route("produto2")]
        public HttpResponseMessage PutProdutos(Produto2 produto)
        {
            if (produto == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Produto2>(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Produto.");
            }
        }

        [HttpDelete]
        [Route("produto2/{produtoId}")]
        public HttpResponseMessage DeleteProdutos(int produtoId)
        {
            if (produtoId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produto2s.Remove(db.Produto2s.Find(produtoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Produto.");
            }
        }

        #endregion Write

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        # endregion Dispose
    }
}