using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Savio.Client.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountStatus
    {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "InActive")]
        InActive,
        [EnumMember(Value = "Deleted")]
        Deleted,
        [EnumMember(Value = "Suspended")]
        Suspended
    }
}
