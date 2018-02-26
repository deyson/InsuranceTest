namespace InsurancePolicy.Core.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum RiskEnum
    {
        [Display(Name = "Bajo")]
        Low,
        [Display(Name = "Medio")]
        Medium,
        [Display(Name = "Medio-Alto")]
        MediumHigh,
        [Display(Name = "Alto")]
        High
    }
}