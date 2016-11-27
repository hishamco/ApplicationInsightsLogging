using Microsoft.AspNetCore.Mvc;

namespace ApplicationInsightsLoggingSample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index() => View();
    }
}
