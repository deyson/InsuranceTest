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
    public class InsuranceRepositoryTest
    {
        InsuranceRepository repository;

        [TestInitialize]
        public void TestSetup()
        {
            InsuranceInitializeDB db = new InsuranceInitializeDB();
            Database.SetInitializer(db);
            Database.SetInitializer(new InsuranceInitializeDB());
            repository = new InsuranceRepository();
        }

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            var result = repository.GetInsurances();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreNotEqual(0, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsInsurance()
        {
            Insurance insuranceToInsert = new Insurance
            {
                Id = 3,
                Name = "Seguro test",
                Coverage = 20,
                Description = "Póliza de Seguro TEST",
                Period = 15,
                Price = 1285000,
                Risk = RiskEnum.MediumHigh,
                Type = InsuranceTypeEnum.Fire,
                Validity = DateTime.Now.AddMonths(4)
            };
            repository.Add(insuranceToInsert);
            var result = repository.FindById(3);
            Assert.AreEqual(result.Name, "Seguro test");
        }

        [TestMethod]
        public void IsRepositoryRemovesInsurance()
        {
            repository.Remove(3);
            var result = repository.FindById(3);
            Assert.IsNull(result);
        }
    }
}
