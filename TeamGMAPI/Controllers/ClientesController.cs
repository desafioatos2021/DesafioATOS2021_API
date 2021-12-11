using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
