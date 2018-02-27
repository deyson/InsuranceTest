namespace InsurancePolicy.Core.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum InsuranceTypeEnum
    {
        [EnumMember(Value = "Terremoto")]
        Earthquake,
        [EnumMember(Value = "Incendio")]
        Fire,
        [EnumMember(Value = "Pérdida")]
        Lost,
        [EnumMember(Value = "Robo")]
        Stole             
    }
}
