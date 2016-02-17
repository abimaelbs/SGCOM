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
    public class MunicipioController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("municipios")]
        public HttpResponseMessage GetMunicipios()
        {
            var result = db.Municipios.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("municipios/{municipioId}")]
        public HttpResponseMessage GetMunicipioById(int municipioId)
        {
            var result = db.Municipios.Where(x => x.Id == municipioId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("municipios")]
        public HttpResponseMessage PostMunicipios(Municipio municipio)
        {
            if (municipio == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();

                var result = municipio;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir municipio.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("municipios")]
        public HttpResponseMessage PutMunicipios(Municipio municipio)
        {
            if (municipio == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Municipio>(municipio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = municipio;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar municipio.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("municipios/{municipioId}")]
        public HttpResponseMessage DeleteMunicipios(int municipioId)
        {
            if (municipioId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Menus.Remove(db.Menus.Find(municipioId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Municipio excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar municipio.");
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
