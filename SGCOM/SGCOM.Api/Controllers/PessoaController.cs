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
    public class PessoaController : ApiController
    {
        #region Objeto Conexão
        private SGCOMDataContext db = new SGCOMDataContext();
        #endregion Objeto Conexão

        #region Filtros

        [HttpGet]
        [Route("pessoas")]
        public HttpResponseMessage GetPessoas()
        {
            var result = db.Pessoas.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("pessoas/{pessoaId}")]
        public HttpResponseMessage GetPessoaById(int pessoaId)
        {
            var result = db.Pessoas.Where(x => x.Id == pessoaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion Filtros

        #region Inserir

        [HttpPost]
        [Route("pessoas")]
        public HttpResponseMessage PostPessoas(Pessoa pessoa)
        {
            if (pessoa == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();

                var result = pessoa;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao inserir Pessoa.");
            }
        }

        #endregion Inserir

        #region Update

        [HttpPut]
        [Route("pessoas")]
        public HttpResponseMessage PutPessoas(Pessoa pessoa)
        {
            if (pessoa == null) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Pessoa>(pessoa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = pessoa;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar Pessoa.");
            }
        }

        #endregion Update

        #region Excluir

        [HttpDelete]
        [Route("pessoas/{pessoaId}")]
        public HttpResponseMessage DeletePessoas(int pessoaId)
        {
            if (pessoaId < 0) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Pessoas.Remove(db.Pessoas.Find(pessoaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Pessoa excluída");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Pessoa.");
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
