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
    public class RepSesionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepSesionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReporteSesion reporteSesion)
        {
            if (ModelState.IsValid)
            {
                _context.ReporteSesion.Update(reporteSesion);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaReporteSesion = _context.ReporteSesion.Where(ant => ant.idPaciente == reporteSesion.idPaciente);
                modelo.reporteSesion = modelo.listaReporteSesion.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = reporteSesion.idPaciente, tabname = "ReporteSesion" });
            }
            return NotFound();
        }
    }
}
