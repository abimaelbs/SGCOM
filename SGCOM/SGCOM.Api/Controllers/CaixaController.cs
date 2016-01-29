using SGCOM.Data.DataContexts;
using SGCOM.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace SGCOM.Api.Controllers
{
    public class CaixaController : ApiController
    {
        private SGCOMDataContext db = new SGCOMDataContext();

        // GET: api/Caixa
        public IQueryable<Caixa> GetCaixas()
        {
            return db.Caixas;
        }

        // GET: api/Caixa/5
        [ResponseType(typeof(Caixa))]
        public IHttpActionResult GetCaixa(int id)
        {
            Caixa caixa = db.Caixas.Find(id);
            if (caixa == null)
            {
                return NotFound();
            }

            return Ok(caixa);
        }

        // PUT: api/Caixa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaixa(int id, Caixa caixa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caixa.Id)
            {
                return BadRequest();
            }

            db.Entry(caixa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaixaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Caixa
        [ResponseType(typeof(Caixa))]
        public IHttpActionResult PostCaixa(Caixa caixa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Caixas.Add(caixa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caixa.Id }, caixa);
        }

        // DELETE: api/Caixa/5
        [ResponseType(typeof(Caixa))]
        public IHttpActionResult DeleteCaixa(int id)
        {
            Caixa caixa = db.Caixas.Find(id);
            if (caixa == null)
            {
                return NotFound();
            }

            db.Caixas.Remove(caixa);
            db.SaveChanges();

            return Ok(caixa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaixaExists(int id)
        {
            return db.Caixas.Count(e => e.Id == id) > 0;
        }
    }
}