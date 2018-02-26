using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using InsurancePolicy.Core;
using InsurancePolicy.Core.Interfaces;

namespace InsurancePolicy.Web.Controllers
{
    public class RequestsApiController : ApiController
    {
        IRequestRepository db;

        public RequestsApiController(IRequestRepository db)
        {
            this.db = db;
        }

        // GET: api/RequestsApi
        public IQueryable<Request> GetRequests()
        {
            return db.GetRequests().AsQueryable();
        }

        // GET: api/RequestsApi/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult GetRequest(int id)
        {
            Request request = db.FindById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/RequestsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(int id, Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            try
            {
                db.Edit(request);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/RequestsApi
        [ResponseType(typeof(Request))]
        public IHttpActionResult PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(request);

            return CreatedAtRoute("DefaultApi", new { id = request.Id }, request);
        }

        // DELETE: api/RequestsApi/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult DeleteRequest(int id)
        {
            Request request = db.FindById(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Remove(id);

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.GetRequests().Any(e => e.Id == id);
        }
    }
}