using Microsoft.AspNetCore.Antiforgery;
using ProyectoSO.Controllers;

namespace ProyectoSO.Web.Host.Controllers
{
    public class AntiForgeryController : ProyectoSOControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
