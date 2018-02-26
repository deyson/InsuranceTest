namespace InsurancePolicy.Infrastructure.Repositories
{
    using System.Collections.Generic;
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
            context.Entry(request).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Request> GetRequests()
        {
            return context.Requests;
        }

        public IEnumerable<Request> GetRequestsByClient(string clientId)
        {
            var result = (from i in context.Requests where i.ClientId == clientId select i).ToList();
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
