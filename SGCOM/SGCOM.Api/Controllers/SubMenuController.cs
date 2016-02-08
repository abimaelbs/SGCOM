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
    public class SubMenuController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("submenus")]
        public HttpResponseMessage GetSubMenus()
        {
            var result = db.SubMenus.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("submenus/{submenuId}")]
        public HttpResponseMessage GetSubmMnuById(int submenuId)
        {
            var result = db.SubMenus.Where(x => x.Id == submenuId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("submenus")]
        public HttpResponseMessage PostSubMenus(SubMenu submenu)
        {
            if (submenu == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.SubMenus.Add(submenu);
                db.SaveChanges();

                var result = submenu;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir SubMenu.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("submenus")]
        public HttpResponseMessage PutSubMenus(SubMenu submenu)
        {
            if (submenu == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<SubMenu>(submenu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = submenu;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar SubMenu.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("submenus/{submenuId}")]
        public HttpResponseMessage DeleteSubMenus(int submenuId)
        {
            if (submenuId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.SubMenus.Remove(db.SubMenus.Find(submenuId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "SubMenu excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir SubMenu.");
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
