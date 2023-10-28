using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SavioApi.Models.Transactions
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
