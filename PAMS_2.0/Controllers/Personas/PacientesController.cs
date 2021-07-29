using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using PAMS_2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetImage(int item)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaPacientes = _context.Paciente.Where(pac => pac.id == item);

            return File(modelo.listaPacientes.First().foto, "image/*");

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
            modelo.listaPacientes = _context.Paciente;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
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
        //Https Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                if (paciente.fotoFile == null)
                {
                    TempData["message"] = "No ha introducido una imagen/foto!!";
                    return View();
                }
               
                if (_context.FormatTelefono(paciente.telefono).Equals("Formato Incorrecto"))
                {
                    TempData["message"] = "El formato del telefono es incorrecto!. Favor de solo introducir numeros y un minimo de 10 digitos!";
                    return View(); 
                } else { paciente.telefono = _context.FormatTelefono(paciente.telefono); }

                if (_context.VerifyTelefono(paciente)) {
                    TempData["message"] = "Ya existe un paciente con este numero telefonico!!";
                    return View(); }
                paciente.fechaRegistro = DateTime.Now;
                paciente.foto = _context.GetByteArrayFromImage(paciente.fotoFile);
                _context.Paciente.Add(paciente);
                _context.SaveChanges();
                _context.SetPsicologia(paciente.id);
                TempData["message"] = "Paciente Registrado con exito!!";
                return RedirectToAction("Index");
            }
            return View();
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

            var paciente = _context.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewModel modelo = new ViewModel();
            modelo.paciente = paciente;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
           
            
            return View(modelo);
        }
        public IActionResult DetallesGenerales(int? id,string tabname)
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
            modelo.paciente = _context.Paciente.Find(id);
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");

            if (tabname == null) {
               
                    TabManagement TM = new TabManagement
                    {
                        ActiveTab = Tab.Pacientes
                    };
                modelo.tabManagement = TM;
            }

            if (tabname != null) { 
                
                TabManagement TM = new TabManagement();
                switch (tabname)
                {
                    case "AntecedentesClinicos":
                        TM.ActiveTab = Tab.AntecedentesClinicos;
                        break;
                    case "Pacientes":
                        TM.ActiveTab = Tab.Pacientes;
                        break;
                    case "AntecedentesFamiliares":
                        TM.ActiveTab = Tab.AntecedentesFamiliares;
                        break;
                    default:
                        TM.ActiveTab = Tab.Pacientes;
                        break;
                }
                modelo.tabManagement = TM;
            }
               
            return View(modelo);
        }


        //TABULACIONES=======================================================
        public IActionResult Detalles(int? id)
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
            modelo.paciente = _context.Paciente.Find(id);
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return PartialView(modelo);
        }
       
    }
}
