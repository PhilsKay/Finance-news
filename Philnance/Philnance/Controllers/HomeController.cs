using Microsoft.AspNetCore.Mvc;
using Philnance.Models;
using Philnance.Repository;
using System.Diagnostics;

namespace Philnance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFinanceNews _financeNews;
        public FinanceNews news;

        public HomeController(ILogger<HomeController> logger, IFinanceNews financeNews)
        {
            _logger = logger;
            _financeNews = financeNews;
        }

        public IActionResult Index()
        {
            news = _financeNews.GetFinanceNews(0);
            return View(news);
        }

        public IActionResult LoadMoreNews(int offset)
        {
            news = _financeNews.GetFinanceNews(offset);
            return View("Index",news);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}