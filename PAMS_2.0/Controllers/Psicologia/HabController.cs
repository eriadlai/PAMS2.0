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
    public class HabController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HabController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Habitos habitos)
        {
            if (ModelState.IsValid)
            {
                _context.Habitos.Update(habitos);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaHabitos = _context.Habitos.Where(ant => ant.idPaciente == habitos.idPaciente);
                modelo.habitos = modelo.listaHabitos.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = habitos.idPaciente, tabname = "Habitos" });
            }
            return NotFound();
        }
    }
}
