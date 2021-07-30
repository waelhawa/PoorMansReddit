using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoorMansReddit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PoorMansReddit.Controllers
{
    public class HomeController : Controller
    {
        private readonly PoorMansRedditDAL _reddit = new PoorMansRedditDAL();

        public async Task<IActionResult> Index(string searchTerm)
        {
            if (!String.IsNullOrEmpty(searchTerm) && ModelState.IsValid)
            {
                var reddit = await _reddit.GetRedditItems(searchTerm);
                return View(reddit);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
