namespace InsurancePolicy.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using InsurancePolicy.Core.Enums;

    public class Insurance
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public InsuranceTypeEnum Type { get; set; }

        public decimal Coverage { get; set; }

        public DateTime Validity { get; set; }

        public int Period { get; set; }

        [Required]
        public decimal Price { get; set; }

        public RiskEnum Risk { get; set; }
    }
}
