using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
