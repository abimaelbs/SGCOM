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
    public class PedidoItensController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("pedidoitens")]
        public HttpResponseMessage GetPedidoitens()
        {
            var result = db.PedidoITens.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("pedidoitens/{pedidoitemID}")]
        public HttpResponseMessage GetPedidoitemById(int pedidoitemId)
        {
            var result = db.PedidoITens.Where(x => x.Id == pedidoitemId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("pedidoitens")]
        public HttpResponseMessage PostPedidoitens(PedidoItens pedidoitens)
        {
            if (pedidoitens == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.PedidoITens.Add(pedidoitens);
                db.SaveChanges();

                var result = pedidoitens;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Item do Pedido.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("pedidoitens")]
        public HttpResponseMessage PutPedidoitens(PedidoItens pedidoitens)
        {
            if (pedidoitens == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<PedidoItens>(pedidoitens).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = pedidoitens;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Item de Pedido.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("pedidoitens/{pedidoitenId}")]
        public HttpResponseMessage DeletePedidoitens(int pedidoitemId)
        {
            if (pedidoitemId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.PedidoITens.Remove(db.PedidoITens.Find(pedidoitemId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Item de Pedido excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Item de Pedido.");
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
