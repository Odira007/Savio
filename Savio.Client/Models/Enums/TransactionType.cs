using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Savio.Client.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionType
    {
        [EnumMember(Value = "Debit")]
        Debit,

        [EnumMember(Value = "Credit")]
        Credit,

        [EnumMember(Value = "Transfer")]
        Transfer,

        [EnumMember(Value = "Withdrawal")]
        Withdrawal,

        [EnumMember(Value = "Deposit")]
        Deposit,
    }
}
