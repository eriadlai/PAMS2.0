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
    public class AntClinicosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AntClinicosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AntecedentesClinicos antecedentesClinicos)
        {
            if (ModelState.IsValid)
            {
                _context.AntecedentesClinicos.Update(antecedentesClinicos);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaAntecedentesClinicos = _context.AntecedentesClinicos.Where(ant => ant.idPaciente == antecedentesClinicos.idPaciente);
                modelo.antecedentesClinicos = modelo.listaAntecedentesClinicos.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = antecedentesClinicos.idPaciente, tabname = "AntecedentesClinicos" });
            }
            return NotFound();
        }
    }
}
