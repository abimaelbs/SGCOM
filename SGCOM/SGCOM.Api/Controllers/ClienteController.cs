using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [MyCorsPolicy]
    [RoutePrefix("api/public")]    
    public class ClienteController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("clientes")]
        public HttpResponseMessage GetClientes()
        {
            var result = db.Clientes.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }

        [HttpGet]
        [Route("clientes/{clienteId}")]
        public HttpResponseMessage GetClienteById(int clienteId)
        {
            var result = db.Clientes.Where(x => x.Id == clienteId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("clientes")]
        public HttpResponseMessage PostClientes(Cliente clientes)
        {
            if (clientes == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();

                var result = clientes;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir cliente.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("clientes")]
        public HttpResponseMessage PutClientes(Cliente cliente)
        {
            if (cliente == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Cliente>(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = cliente;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar cliente.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("clientes/{clienteId}")]
        public HttpResponseMessage DeleteClientes(int clienteId)
        {
            if (clienteId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Clientes.Remove(db.Clientes.Find(clienteId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar cliente.");
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
