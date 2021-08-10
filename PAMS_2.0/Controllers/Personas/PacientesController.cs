
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using PAMS_2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tab = PAMS_2._0.Data.Tab;
using Tabulador = iText.Layout.Element.Tab;

namespace PAMS_2._0.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PacientesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env=env;
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
                if (HttpContext.Session.GetString("rol") != "Psicologo") {
                    return RedirectToAction("Index", "Home");
                }
                
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
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

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
                paciente.ultimaActualizacion = DateTime.Now;
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
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

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
        //Https Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Paciente paciente)
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            if (ModelState.IsValid)
            {
                paciente.telefono = _context.CleanTelefonoPaciente(paciente);
                if (paciente.fotoFile != null)
                {
                    paciente.foto = _context.GetByteArrayFromImage(paciente.fotoFile);
                }
                else
                {
                    paciente.foto = _context.GetPacienteByte(paciente);
                    paciente.fotoFile = _context.GetFormFile(_env);
                }
                if (_context.FormatTelefono(paciente.telefono).Equals("Formato Incorrecto"))
                {
                    TempData["message"] = "El formato del telefono es incorrecto!. Favor de solo introducir numeros y 10 digitos!";
                    ViewModel modelo = new ViewModel();
                    modelo.paciente = paciente;
                    modelo.Sesion = HttpContext.Session.GetString("usuario");
                    modelo.rol = HttpContext.Session.GetString("rol");
                    return View(modelo);
                }
                else { paciente.telefono = _context.FormatTelefono(paciente.telefono); }
                paciente.ultimaActualizacion = DateTime.Now;
                _context.Paciente.Update(paciente);
                if (_context.VerifyTelefono(paciente))
                {
                    TempData["message"] = "Ya existe un paciente con este numero telefonico!!";
                    return View();
                }
                _context.SaveChanges();
                TempData["message"] = "Los datos del Paciente se han actualizado";
                return RedirectToAction("Index");
            }

            return View();
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
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

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
        //Https Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePaciente(int? id)
        {
            var paciente = _context.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            _context.deleteDatos(paciente.id);
            _context.Paciente.Remove(paciente);

            _context.SaveChanges();
            TempData["message"] = "El Paciente ha sido Eliminado";

            return RedirectToAction("Index");
        }
        public IActionResult DetallesGenerales(int? id,string tabname)
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (HttpContext.Session.GetString("rol") != "Administrador")
            {
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

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
                    case "CirculoSocial":
                        TM.ActiveTab = Tab.CirculoSocial;
                        break;
                    case "EstadoMental":
                        TM.ActiveTab = Tab.EstadoMental;
                        break;
                    case "Familiares":
                        TM.ActiveTab = Tab.Familiares;
                        break;
                    case "Habitos":
                        TM.ActiveTab = Tab.Habitos;
                        break;
                    case "HistorialSexual":
                        TM.ActiveTab = Tab.HistorialSexual;
                        break;
                    case "Problema":
                        TM.ActiveTab = Tab.Problema;
                        break;
                    case "ReporteSesion":
                        TM.ActiveTab = Tab.ReporteSesion;
                        break;
                    default:
                        TM.ActiveTab = Tab.Pacientes;
                        break;
                }
                modelo.tabManagement = TM;
            }
               
            return View(modelo);
        }

        //PDF======================================================================
        public IActionResult PDF(int? id) {
            var paciente = _context.Paciente.Find(id);
            _context.PDF(paciente.id, _env);
            //====================================
            ViewModel modelo = new ViewModel();
            modelo.listaPacientes = _context.Paciente;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            TempData["message"] = "PDF Generado!";
            return RedirectToAction("Index", "Pacientes", modelo);
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
                if (HttpContext.Session.GetString("rol") != "Psicologo")
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            ViewModel modelo = new ViewModel();
            modelo.paciente = _context.Paciente.Find(id);
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return PartialView(modelo);
        }
       
    }
}
