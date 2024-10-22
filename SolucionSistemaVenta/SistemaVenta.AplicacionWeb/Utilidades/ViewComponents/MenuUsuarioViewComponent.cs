using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SistemaVenta.AplicacionWeb.Utilidades.ViewComponents
{
    public class MenuUsuarioViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string nombreUsuario = "";
            string urlFotousuario = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimUser.Claims
                    .Where(c=>c.Type== ClaimTypes.Name)
                    .Select(c=>c.Value).SingleOrDefault();

                urlFotousuario = ((ClaimsIdentity)claimUser.Identity).FindFirst("UrlFoto").Value;
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            ViewData["urlFotoUsuario"] = urlFotousuario;
            return View();
        }
    }
}
