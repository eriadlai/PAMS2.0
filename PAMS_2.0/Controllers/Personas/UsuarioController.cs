using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using PAMS_2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public UsuarioController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public IActionResult GetImage(int item)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaUsuarios = _context.Usuario.Where(usu => usu.id == item);

            return File(modelo.listaUsuarios.First().foto, "image/*");

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewModel modelo = new ViewModel();
            modelo.listaUsuarios = _context.Usuario.Where(usu => usu.email != HttpContext.Session.GetString("usuario"));
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(model: modelo);
        }
        //Https Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.email = usuario.email.Trim();
                usuario.nombre = usuario.nombre.Trim();
                usuario.apellido = usuario.apellido.Trim();
                usuario.password = usuario.password.Trim();
                usuario.telefono = _context.CleanTelefonoUser(usuario);

                if (usuario.fotoFile == null)
                {
                    TempData["message"] = "No ha introducido una imagen/foto!!";
                    return View();
                }
                if (_context.VerifyEmail(usuario.email))
                {
                    TempData["message"] = "Un usuario con el correo: "+usuario.email+" ya existe!!";
                    return View();
                }
                if (_context.FormatTelefono(usuario.telefono).Equals("Formato Incorrecto")) {
                    TempData["message"] = "El formato del telefono es incorrecto!. Favor de solo introducir numeros y un minimo de 10 digitos!";
                    return View();
                }
                else { usuario.telefono = _context.FormatTelefono(usuario.telefono); }

                usuario.foto = _context.GetByteArrayFromImage(usuario.fotoFile);

                //PROCESO HASHEO+SALT PASSWORD=================================================================================
              
                //usuario.password = _context.HashPassword(usuario.password);

                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                TempData["message"] = "Usuario creado con exito!!";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Https Get Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewModel modelo = new ViewModel();
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        //Https Get Edit
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewModel modelo = new ViewModel();
            modelo.usuario = usuario;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        //Https Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            usuario.password = _context.GetUserPass(usuario);
            if (ModelState.IsValid)
            {
                usuario.email = usuario.email.Trim();
                usuario.nombre = usuario.nombre.Trim();
                usuario.apellido = usuario.apellido.Trim();
                usuario.telefono = _context.CleanTelefonoUser(usuario);
               
                if (usuario.fotoFile != null) {
                    usuario.foto = _context.GetByteArrayFromImage(usuario.fotoFile);
                }
                else
                {
                    usuario.foto = _context.GetUserByte(usuario);
                    usuario.fotoFile = _context.GetFormFile(_env);
                }
                if (_context.FormatTelefono(usuario.telefono).Equals("Formato Incorrecto"))
                {
                    TempData["message"] = "El formato del telefono es incorrecto!. Favor de solo introducir numeros y un minimo de 10 digitos!";
                    ViewModel modelo = new ViewModel();
                    modelo.usuario = usuario;
                    modelo.Sesion = HttpContext.Session.GetString("usuario");
                    modelo.rol = HttpContext.Session.GetString("rol");
                    return View(modelo);
                }
                else { usuario.telefono = _context.FormatTelefono(usuario.telefono); }

                _context.Usuario.Update(usuario);
                if (_context.VerifyEmailEdit(usuario))
                {
                    TempData["message"] = "Un usuario con el correo: " + usuario.email + " ya existe!!";

                    ViewModel modelo = new ViewModel();
                    modelo.usuario = usuario;
                    modelo.Sesion = HttpContext.Session.GetString("usuario");
                    modelo.rol = HttpContext.Session.GetString("rol");
                    return View(modelo);
                }
            
                _context.SaveChanges();
                TempData["message"] = "El usuario se ha actualizado";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Https Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUsuario(int? id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
            TempData["message"] = "El usuario se ha Eliminado";

            return RedirectToAction("Index");
        }
        //Https Get Delete
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewModel modelo = new ViewModel();
            modelo.usuario = usuario;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        //Https Get Edit
        public IActionResult EditPassword(int? id)
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewModel modelo = new ViewModel();
            modelo.usuario = usuario;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        //Https Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPassword(Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                usuario.foto = _context.GetUserByte(usuario);
                usuario.fotoFile = _context.GetFormFile(_env);
                usuario.password = _context.HashPassword(usuario.password);
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                TempData["message"] = "Contraseña Actualizada!";
                return RedirectToAction("Index");
            }

            return View();
        }

    }
    
}

