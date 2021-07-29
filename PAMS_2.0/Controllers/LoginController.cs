using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using PAMS_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("usuario") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string User, string Pass)
        {
            Boolean mssg=false;
                IEnumerable<Usuario> listUsuario = _context.Usuario;

                foreach (var item in listUsuario.ToArray())
                {
                    
                    if (item.email.Equals(User.Trim()) && _context.VerifyHashedPassword(item.password,Pass.Trim())) 
                    {
                        HttpContext.Session.SetString("usuario", item.email);
                        HttpContext.Session.SetString("rol", item.rol);
                         mssg = true;
                        break;
                    }
                    
                }
                 if (!mssg) {
                 TempData["message"] = "Credenciales Incorrectas!";
                return View();
                 }
                return RedirectToAction("Index", "Home");
            
           
        }
        public ActionResult Perfil()
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewModel modelo = new ViewModel();
           modelo.listaUsuarios = _context.Usuario.Where(usu => usu.email.Equals(HttpContext.Session.GetString("usuario")));
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
    }
}
