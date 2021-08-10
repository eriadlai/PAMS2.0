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
    public class ProController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Problema problema)
        {
            if (ModelState.IsValid)
            {
                var paciente = _context.Paciente.Find(problema.idPaciente);
                paciente.ultimaActualizacion = DateTime.Now;
                _context.Paciente.Update(paciente);

                _context.Problema.Update(problema);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaProblema = _context.Problema.Where(ant => ant.idPaciente == problema.idPaciente);
                modelo.problema = modelo.listaProblema.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = problema.idPaciente, tabname = "Problema" });
            }
            return NotFound();
        }
    }
}
