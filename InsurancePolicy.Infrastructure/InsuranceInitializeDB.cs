namespace InsurancePolicy.Infrastructure
{
    using System;
    using System.Data.Entity;

    using InsurancePolicy.Core;
    using InsurancePolicy.Core.Enums;

    public class InsuranceInitializeDB : DropCreateDatabaseIfModelChanges<InsuranceContext>
    {
        protected override void Seed(InsuranceContext context)
        {
            context.Insurances.Add(new Insurance
            {
                Id = 1,
                Name = "Seguro hogar",
                Coverage = 78,
                Description = "Póliza de Seguro Hogar",
                Period = 6,
                Price = 568000,
                Risk = RiskEnum.Medium,
                Type = InsuranceTypeEnum.Earthquake,
                Validity = DateTime.Now
            });
            context.Insurances.Add(new Insurance
            {
                Id = 2,
                Name = "Seguro vehicular",
                Coverage = 80,
                Description = "Póliza de Seguro Vehículo",
                Period = 5,
                Price = 785000,
                Risk = RiskEnum.High,
                Type = InsuranceTypeEnum.Stole,
                Validity = DateTime.Now.AddMonths(5)
            });
            context.Requests.Add(new Request
            {
                Id = 1,
                ClientId = "deyson@gmail.com",
                InsuranceId = 1
            });
            context.Requests.Add(new Request
            {
                Id = 1,
                ClientId = "ludifi@gmail.com",
                InsuranceId = 2
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
