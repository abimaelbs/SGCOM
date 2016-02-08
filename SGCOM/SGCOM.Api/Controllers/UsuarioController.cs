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
    public class UsuarioController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("usuarios")]
        public HttpResponseMessage GetUsuarios()
        {
            var result = db.Usuarios.ToList();
            if(result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);
        }

        [HttpGet]        
        [Route("usuarios/{usuarioId}")]
        public HttpResponseMessage GetUsuarioById(int usuarioId)
        {            
            var result = db.Usuarios.Where(x => x.Id == usuarioId).ToList();
            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("usuarios")]
        public HttpResponseMessage PostUsuarios(Usuario usuario)
        {
            if (usuario == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                var result = usuario;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir usuário.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("usuarios")]
        public HttpResponseMessage PutUsuarios(Usuario usuario)
        {
            if (usuario == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {                
                db.Entry<Usuario>(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = usuario;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar usuário.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("usuarios/{usuarioId}")]
        public HttpResponseMessage DeleteUsuarios(int usuarioId)
        {
            if (usuarioId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Usuarios.Remove(db.Usuarios.Find(usuarioId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Usuário excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar usuário.");
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