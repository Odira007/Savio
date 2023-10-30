using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Savio.Client.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Savio.Client.ViewModels;

namespace Savio.Client.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly DashboardViewModel _viewModel;

        public TransactionsController(ILogger<TransactionsController> logger, DashboardViewModel viewModel)
        {
            _logger = logger;
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public async Task<IActionResult> GetTransactions()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5126/api");

                    var response = await client.GetAsync("transactions");
                    response.EnsureSuccessStatusCode();
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var conversionResult = JsonConvert.DeserializeObject<IEnumerable<Transaction>>(responseContent);

                    _viewModel.transactions = conversionResult;
                    return View(_viewModel);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, ex.Message);
                    throw;
                }
            }

        }
    }
}
