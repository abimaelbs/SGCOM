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
    public class PermissaoController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("permissoes")]
        public HttpResponseMessage GetPermissoes()
        {
            var result = db.Permissoes.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("permissoes/{permissaoId}")]
        public HttpResponseMessage GetPermissaoById(int permissaoId)
        {
            var result = db.Permissoes.Where(x => x.Id == permissaoId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("permissoes")]
        public HttpResponseMessage PostPermissoes(Permissao permissao)
        {
            if (permissao == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Permissoes.Add(permissao);
                db.SaveChanges();

                var result = permissao;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Permissão.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("permissoes")]
        public HttpResponseMessage PutPermissoes(Permissao permissao)
        {
            if (permissao == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Permissao>(permissao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = permissao;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Permissão.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("permissoes/{permissaoId}")]
        public HttpResponseMessage DeletePermissoes(int permissaoId)
        {
            if (permissaoId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Permissoes.Remove(db.Permissoes.Find(permissaoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Permissão excluída");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Permissão.");
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
