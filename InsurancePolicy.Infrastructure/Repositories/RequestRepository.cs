namespace InsurancePolicy.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using InsurancePolicy.Core;
    using InsurancePolicy.Core.Interfaces;

    public class RequestRepository : IRequestRepository
    {
        InsuranceContext context = new InsuranceContext();

        public void Add(Request request)
        {
            context.Requests.Add(request);
            context.SaveChanges();
        }

        public void Edit(Request request)
        {
            context.Entry(request).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Request FindById(int id)
        {
            var result = (from r in context.Requests where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Request> GetRequests()
        {
            return context.Requests;
        }

        public IEnumerable<Request> GetRequestsByClient(string clientId)
        {
            var result = (from r in context.Requests where r.ClientId == clientId select r).ToList();
            return result;
        }

        public void Remove(int id)
        {
            Request request = context.Requests.Find(id);
            context.Requests.Remove(request);
            context.SaveChanges();
        }
    }
}
