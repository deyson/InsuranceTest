namespace InsurancePolicy.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IRequestRepository
    {
        void Add(Request request);
        void Edit(Request request);
        void Remove(int id);
        IEnumerable<Request> GetRequests();
        IEnumerable<Request> GetRequestsByClient(string clientId);
    }
}
