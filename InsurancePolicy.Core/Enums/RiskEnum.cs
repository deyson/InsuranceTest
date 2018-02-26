namespace InsurancePolicy.Core.Enums
{
    using System.ComponentModel;

    public enum RiskEnum
    {
        [Description("Bajo")]
        Low,
        [Description("Medio")]
        Medium,
        [Description("Medio-Alto")]
        MediumHigh,
        [Description("Alto")]
        High
    }
}