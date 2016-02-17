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
    public class PedidoController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("pedidos")]
        public HttpResponseMessage GetPedidos()
        {
            var result = db.Pedidos.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("pedidos/{pedidoId}")]
        public HttpResponseMessage GetPedidoById(int pedidoId)
        {
            var result = db.Pedidos.Where(x => x.Id == pedidoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("pedidos")]
        public HttpResponseMessage PostPedidos(Pedido pedido)
        {
            if (pedido == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();

                var result = pedido;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Pedido.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("pedidos")]
        public HttpResponseMessage PutPedidos(Pedido pedido)
        {
            if (pedido == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Pedido>(pedido).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = pedido;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Pedido.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("pedidos/{pedidoId}")]
        public HttpResponseMessage DeletePedidos(int pedido)
        {
            if (pedido < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Pedidos.Remove(db.Pedidos.Find(pedido));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Pedido excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Pedido.");
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
