using Savio.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savio.Client.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Transaction> transactions { get; set; }
    }
}
