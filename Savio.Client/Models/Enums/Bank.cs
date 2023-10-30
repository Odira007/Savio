using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Savio.Client.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Bank
    {
        [EnumMember(Value = "Access Bank")]
        AccessBank,

        [EnumMember(Value = "First Bank of Nigeria")]
        FirstBankOfNigeria,

        [EnumMember(Value = "Guaranty Trust Bank")]
        GuarantyTrustBank,

        [EnumMember(Value = "Zenith Bank")]
        ZenithBank,

        [EnumMember(Value = "United Bank for Africa")]
        UnitedBankforAfrica,

        [EnumMember(Value = "Ecobank Nigeria")]
        EcobankNigeria,

        [EnumMember(Value = "Union Bank of Nigeria")]
        UnionBankofNigeria,

        [EnumMember(Value = "Stanbic IBTC Bank")]
        StanbicIBTCBank,

        [EnumMember(Value = "Fidelity Bank")]
        FidelityBank,

        [EnumMember(Value = "Sterling Bank")]
        SterlingBank,

        [EnumMember(Value = "Keystone Bank")]
        KeystoneBank,

        [EnumMember(Value = "Polaris Bank")]
        PolarisBank,

        [EnumMember(Value = "Wema Bank")]
        WemaBank,

        [EnumMember(Value = "Heritage Bank")]
        HeritageBank,

        [EnumMember(Value = "Unity Bank")]
        UnityBank
    }
}
