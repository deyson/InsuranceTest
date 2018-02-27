namespace InsurancePolicy.Core.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RiskEnum
    {
        [EnumMember(Value = "Bajo")]
        Low,
        [EnumMember(Value = "Medio")]
        Medium,
        [EnumMember(Value = "Medio-Alto")]
        MediumHigh,
        [EnumMember(Value = "Alto")]
        High
    }
}