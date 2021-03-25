using Microsoft.AspNetCore.Mvc;


namespace AMS.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Redirect("/Swagger");
    }
}
