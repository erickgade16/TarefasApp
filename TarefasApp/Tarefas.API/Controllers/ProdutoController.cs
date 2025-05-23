using Microsoft.AspNetCore.Mvc;

namespace Tarefas.API.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
