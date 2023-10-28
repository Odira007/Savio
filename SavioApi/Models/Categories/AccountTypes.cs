using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SavioApi.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountType
    {
        [EnumMember(Value = "Savings")]
        Savings,
        
        [EnumMember(Value = "Current")]
        Current,
        
        [EnumMember(Value = "MoneyMarket")]
        MoneyMarket,
        
        [EnumMember(Value = "CertificateOfDeposit")]
        CertificateOfDeposit,
        
        [EnumMember(Value = "IRA")]
        IRA,
        
        [EnumMember(Value = "Business")]
        Business,
        
        [EnumMember(Value = "Joint")]
        Joint,
        
        [EnumMember(Value = "Student")]
        Student,
        
        [EnumMember(Value = "Trust")]
        Trust,
        
        [EnumMember(Value = "Custodial")]
        Custodial
    }
}
