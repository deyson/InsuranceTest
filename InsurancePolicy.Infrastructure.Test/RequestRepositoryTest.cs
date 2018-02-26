namespace InsurancePolicy.Infrastructure.Test
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using InsurancePolicy.Core;
    using InsurancePolicy.Core.Enums;
    using InsurancePolicy.Infrastructure.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RequestRepositoryTest
    {
        RequestRepository repository;

        [TestInitialize]
        public void TestSetup()
        {
            InsuranceInitializeDB db = new InsuranceInitializeDB();
            Database.SetInitializer(db);
            Database.SetInitializer(new InsuranceInitializeDB());
            repository = new RequestRepository();
        }

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            var result = repository.GetRequests();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreNotEqual(0, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsRequest()
        {
            Request requestToInsert = new Request
            {
                Id = 3,
                ClientId = "test@gmail.com",
                InsuranceId = 1
            };
            repository.Add(requestToInsert);
            var result = repository.GetRequestsByClient("test@gmail.com").ToList();
            Assert.IsTrue(result.Count > 0);
        }
    }
}
