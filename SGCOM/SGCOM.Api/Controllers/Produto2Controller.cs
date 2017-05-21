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

        /// <summary>
        /// Retorna lista de Produtos
        /// </summary> 
        [HttpGet]
        [Route("produtos2")]
        public HttpResponseMessage GetProdutos()
        {
            var result = db.Produto2s.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Retorna Produto por Id
        /// </summary>
        /// <param name="produtoId">Identificador</param>
        /// <returns></returns>
        [HttpGet]
        [Route("produto2/{produtoId}")]
        public HttpResponseMessage GetProdutoById(int produtoId)
        {
            var result = db.Produto2s.Where(x => x.Id == produtoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion Read

        #region Write
        /// <summary>
        /// Adiciona novo produto
        /// </summary>
        /// <param name="produto">Produto</param>
        /// <returns></returns>
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

        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="produto">Produto</param>
        /// <returns></returns>
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

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="produtoId"></param>
        /// <returns></returns>
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