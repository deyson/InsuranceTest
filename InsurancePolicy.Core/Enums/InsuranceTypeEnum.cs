namespace InsurancePolicy.Core.Enums
{
    using System.ComponentModel;

    public enum InsuranceTypeEnum
    {
        [Description("Terremoto")]
        Earthquake,
        [Description("Incendio")]
        Fire,
        [Description("Pérdida")]
        Lost,
        [Description("Robo")]
        Stole             
    }
}
