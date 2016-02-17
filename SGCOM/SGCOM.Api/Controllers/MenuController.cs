using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [MyCorsPolicy]
    [RoutePrefix("api/public")]
    public class MenuController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("menus")]
        public HttpResponseMessage GetMenus()
        {
            var result = db.Menus.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("menus/{menuId}")]
        public HttpResponseMessage GetMenusById(int menuId)
        {
            var result = db.Menus.Where(x => x.Id == menuId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("menus")]
        public HttpResponseMessage PostMenus(Menu menu)
        {
            if (menu == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Menus.Add(menu);
                db.SaveChanges();

                var result = menu;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir menu.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("menus")]
        public HttpResponseMessage PutMenus(Menu menu)
        {
            if (menu == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Menu>(menu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = menu;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar menu.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("menus/{menuId}")]
        public HttpResponseMessage DeleteMenus(int menuId)
        {
            if (menuId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Menus.Remove(db.Menus.Find(menuId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Menu excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar menu.");
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