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
    public class ProdutoController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("produtos")]
        public HttpResponseMessage GetProdutos()
        {
            var result = db.Produtos.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("produtos/{produtoId}")]
        public HttpResponseMessage GetProdutoById(int produtoId)
        {
            var result = db.Produtos.Where(x => x.Id == produtoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("produtos")]
        public HttpResponseMessage PostProdutos(Produto produto)
        {
            if (produto == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Produto.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("produtos")]
        public HttpResponseMessage PutProdutos(Produto produto)
        {
            if (produto == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Produto>(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Produto.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("produtos/{produtoId}")]
        public HttpResponseMessage DeleteProdutos(int produtoId)
        {
            if (produtoId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produtos.Remove(db.Produtos.Find(produtoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Produto.");
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
