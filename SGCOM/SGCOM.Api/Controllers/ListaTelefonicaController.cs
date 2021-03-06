﻿using SGCOM.Data.DataContexts;
using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SGCOM.Api.Controllers
{
    [MyCorsPolicy]
    [RoutePrefix("api/public")]
    public class ListaTelefonicaController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        /// <summary>
        /// Retorna Lista de Contatos
        /// </summary>        
        [HttpGet]
        [Route("contatos")]
        public HttpResponseMessage GetContatos()
        {
            var result = db.ListaTelefonica.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("listaTelefonicas")]
        public HttpResponseMessage GetListaTelefonicas()
        {
            var result = db.ListaTelefonica.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [MyCorsPolicy]
        [HttpGet]
        [Route("contatos/{id}")]
        public HttpResponseMessage GetListaTelefonicasById(int id)
        {
            var result = db.ListaTelefonica.Where(x=>x.Id== id).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion Filtros

        #region Inserir
        [HttpPost]
        [Route("contatos")]
        public HttpResponseMessage PostContato(ListaTelefonica contato)
        {
            if (contato == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.ListaTelefonica.Add(contato);
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir contato.");
            }
        }
        #endregion Inserir

        #region Update
        [MyCorsPolicy]
        [HttpPut]
        [Route("contatos")]
        public HttpResponseMessage PutListaTelefonicas(ListaTelefonica listaTelefonica)
        {
            if (listaTelefonica == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<ListaTelefonica>(listaTelefonica).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = listaTelefonica;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar listaTelefonica.");
            }
        }
        #endregion Update

        #region Excluir

        [MyCorsPolicy]
        [HttpDelete]
        [Route("contatos/{id}")]        
        public HttpResponseMessage DeleteListaTelefonicas(int id)
        {            
            if (id < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.ListaTelefonica.Remove(db.ListaTelefonica.Find(id));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "ListaTelefonica excluído");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar listaTelefonica.");
            }
        }

        #endregion Excluir

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion Dispose
    }
}
