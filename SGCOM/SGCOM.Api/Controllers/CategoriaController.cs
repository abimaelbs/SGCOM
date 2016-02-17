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
    public class CategoriaController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var result = db.Categorias.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound,result);
        }

        [HttpGet]
        [Route("categorias/{categoriaId}")]
        public HttpResponseMessage GetCategoriaById(int categoriaId)
        {
            var result = db.Categorias.Where(x => x.Id == categoriaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("categorias")]
        public HttpResponseMessage PostCategorias(Categoria categoria)
        {
            if (categoria == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();

                var result = categoria;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir categoria.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("categorias")]
        public HttpResponseMessage PutUsuarios(Categoria categoria)
        {
            if (categoria == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Categoria>(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = categoria;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar categoria.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("categorias/{categoriaId}")]
        public HttpResponseMessage DeleteCategorias(int categoriaId)
        {
            if (categoriaId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Categorias.Remove(db.Categorias.Find(categoriaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Categoria excluída");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar categoria.");
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
