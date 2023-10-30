using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Savio.Client.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Successful")]
        Successful,

        [EnumMember(Value = "Declined")]
        Declined,

        [EnumMember(Value = "Failed")]
        Failed,

        [EnumMember(Value = "Refunded")]
        Refunded,

    }
}
