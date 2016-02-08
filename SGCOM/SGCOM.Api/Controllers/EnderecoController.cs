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
    [RoutePrefix("api/public")]
    public class EnderecoController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("enderecos")]
        public HttpResponseMessage GetEnderecos()
        {
            var result = db.Enderecos.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }

        [HttpGet]
        [Route("enderecos/{enderecoId}")]
        public HttpResponseMessage GetEmpresaById(int enderecoId)
        {
            var result = db.Enderecos.Where(x => x.Id == enderecoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("enderecos")]
        public HttpResponseMessage PostEnderecos(Endereco endereco)
        {
            if (endereco == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Enderecos.Add(endereco);
                db.SaveChanges();

                var result = endereco;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir endereço.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("enderecos")]
        public HttpResponseMessage PutEnderecos(Endereco endereco)
        {
            if (endereco == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Endereco>(endereco).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = endereco;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar endereço.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("enderecos/{enderecoId}")]
        public HttpResponseMessage DeleteEnderecos(int enderecoId)
        {
            if (enderecoId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Enderecos.Remove(db.Enderecos.Find(enderecoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Endereço excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar endereço.");
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
