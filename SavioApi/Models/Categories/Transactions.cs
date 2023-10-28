namespace SavioApi.Models.Categories
{
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SavioApi.Models.Transactions
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

}