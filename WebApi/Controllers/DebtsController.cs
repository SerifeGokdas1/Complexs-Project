using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DebtsController : ApiController
    {
        private ComplexsEntities1 db = new ComplexsEntities1();

        // GET: api/Debts
        public IQueryable<Debt> GetDebts()
        {
            return db.Debts;
        }

        // GET: api/Debts/5
        [ResponseType(typeof(Debt))]
        public async Task<IHttpActionResult> GetDebt(int id)
        {
            Debt debt = await db.Debts.FindAsync(id);
            if (debt == null)
            {
                return NotFound();
            }

            return Ok(debt);
        }

        // PUT: api/Debts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDebt(int id, Debt debt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != debt.DebtId)
            {
                return BadRequest();
            }

            db.Entry(debt).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebtExists(id))
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

        // POST: api/Debts
        [ResponseType(typeof(Debt))]
        public async Task<IHttpActionResult> PostDebt(Debt debt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Debts.Add(debt);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = debt.DebtId }, debt);
        }

        // DELETE: api/Debts/5
        [ResponseType(typeof(Debt))]
        public async Task<IHttpActionResult> DeleteDebt(int id)
        {
            Debt debt = await db.Debts.FindAsync(id);
            if (debt == null)
            {
                return NotFound();
            }

            db.Debts.Remove(debt);
            await db.SaveChangesAsync();

            return Ok(debt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DebtExists(int id)
        {
            return db.Debts.Count(e => e.DebtId == id) > 0;
        }
    }
}