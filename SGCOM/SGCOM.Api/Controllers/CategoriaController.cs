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

        #region Read

        /// <summary>
        /// Retorna lista de Categorias
        /// </summary>        
        [HttpGet]
        [Route("categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var result = db.Categorias.ToList();

            if (result.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateResponse(HttpStatusCode.NotFound,result);
        }

        /// <summary>
        /// Retorna Categoria por Id
        /// </summary>
        /// <param name="categoriaId">Id categoria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("categoria/{categoriaId}")]
        public HttpResponseMessage GetCategoriaById(int categoriaId)
        {
            var result = db.Categorias.Where(x => x.Id == categoriaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion Read

        #region Write

        /// <summary>
        /// Adiciona nova Categoria
        /// </summary>
        /// <param name="categoria">Categoria</param>

        [HttpPost]
        [Route("categoria")]
        public HttpResponseMessage PostCategoria(Categoria categoria)
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

        /// <summary>
        /// Alterar uma Categoria
        /// </summary>
        /// <param name="categoria">Categoria</param>        
        [HttpPut]
        [Route("categoria")]
        public HttpResponseMessage PutCategoria(Categoria categoria)
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

        /// <summary>
        /// Excluir uma Categoria
        /// </summary>
        /// <param name="categoriaId">Id Categoria</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("categoria/{categoriaId}")]
        public HttpResponseMessage DeleteCategoria(int categoriaId)
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir categoria.");
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
