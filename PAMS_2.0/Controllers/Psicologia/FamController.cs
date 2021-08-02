using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using PAMS_2._0.Models.Psicologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers.Psicologia
{
    public class FamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Familiares familiares)
        {
            if (ModelState.IsValid)
            {
                
                _context.Familiares.Add(familiares);
                _context.SaveChanges();
                TempData["message"] = "Pariente Agregado con exito!!";
                ViewModel modelo = new ViewModel();
                modelo.listaFamiliares = _context.Familiares.Where(ant => ant.idPaciente == familiares.idPaciente);
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = modelo.listaFamiliares.First().idPaciente, tabname = "Familiares" });

            }
            return View();
        }
        //GET 
        public IActionResult Create(int id)
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
            Familiares familiares = new Familiares();
            modelo.familiares = familiares;
            modelo.familiares.idPaciente = id;
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Familiares familiares)
        {
            if (ModelState.IsValid)
            {
                _context.Familiares.Update(familiares);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaFamiliares = _context.Familiares.Where(ant => ant.idPaciente == familiares.idPaciente);
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = modelo.listaFamiliares.First().idPaciente, tabname = "Familiares" });
            }
            return NotFound();
        }
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

            var familiar = _context.Familiares.Find(id);
            if (familiar == null)
            {
                return NotFound();
            }
            ViewModel modelo = new ViewModel();
            modelo.familiares = familiar;
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        //Https Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var Familiar= _context.Familiares.Find(id);
            var idP = Familiar.idPaciente;
            if (Familiar == null)
            {
                return NotFound();
            }

            _context.Familiares.Remove(Familiar);
            _context.SaveChanges();
            TempData["message"] = "El pariente se ha Eliminado";

            ViewModel modelo = new ViewModel();
            modelo.listaFamiliares = _context.Familiares.Where(ant => ant.idPaciente == idP);
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return RedirectToAction("DetallesGenerales", "Pacientes", new { id = modelo.listaFamiliares.First().idPaciente, tabname = "Familiares" });

        }
    }
}
