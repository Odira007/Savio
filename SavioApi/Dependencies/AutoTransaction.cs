// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace SavioApi.Dependencies
// {
//     public static class AutoTransaction
//     {
//         public Transaction doo(){
            

//             var balance = sendingaccount.AccountBalance;
//             if (balance < dto.TransactionAmount)
//             {
//                 return x.Declined("INSUFFICIENT ACCOUNT BALANCE");
//             }
//             await _account.UpdateAccountBalance(dto.AccountId, balance - dto.TransactionAmount);
//             await _account.UpdateAccountBalance(
//                 receivingAccount.AccountId,
//                 receivingAccount.AccountBalance + dto.TransactionAmount
//             );
//             transaction.Account = sendingaccount;
//             transaction.TransactionTime = DateTime.Now;
//             transaction.TransactionStatus=TransactionStatus.Successful;
//             transaction.ReceivingAccount = receivingAccount.AccountId;
//             transaction.TransactionType = TransactionType.Debit;
//             var response = x.Approved("TRANSFER SUCCESSFUL");
//             response.Data = transaction;
//             await _context.Transactions.AddAsync(transaction);
//             await _context.SaveChangesAsync();
//             return response;
//         }
//         }
//     }
// }