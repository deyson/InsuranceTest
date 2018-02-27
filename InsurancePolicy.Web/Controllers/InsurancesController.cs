using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InsurancePolicy.Core;
using InsurancePolicy.Core.Interfaces;
using InsurancePolicy.Infrastructure;

namespace InsurancePolicy.Web.Controllers
{
    public class InsurancesController : ApiController
    {
        IInsuranceRepository db;

        public InsurancesController(IInsuranceRepository db)
        {
            this.db = db;
        }

        // GET: api/Insurances
        [Authorize]
        public IQueryable<Insurance> GetInsurances()
        {
            return db.GetInsurances().AsQueryable();
        }

        // GET: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        [Authorize]
        public IHttpActionResult GetInsurance(int id)
        {
            Insurance insurance = db.FindById(id);
            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutInsurance(int id, Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.Id)
            {
                return BadRequest();
            }
                        
            try
            {
                db.Edit(insurance);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
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

        // POST: api/Insurances
        [ResponseType(typeof(Insurance))]
        [Authorize]
        public IHttpActionResult PostInsurance(Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(insurance);

            return CreatedAtRoute("DefaultApi", new { id = insurance.Id }, insurance);
        }

        // DELETE: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        [Authorize]
        public IHttpActionResult DeleteInsurance(int id)
        {
            Insurance insurance = db.FindById(id);
            if (insurance == null)
            {
                return NotFound();
            }

            db.Remove(id);

            return Ok(insurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsuranceExists(int id)
        {
            return db.GetInsurances().Any(e => e.Id == id);
        }
    }
}