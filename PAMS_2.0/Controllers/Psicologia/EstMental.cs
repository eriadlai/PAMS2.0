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
    public class EstMental : Controller
    {
        private readonly ApplicationDbContext _context;
        public EstMental(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EstadoMental estadoMental)
        {
            if (ModelState.IsValid)
            {
                _context.EstadoMental.Update(estadoMental);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaEstadoMental = _context.EstadoMental.Where(ant => ant.idPaciente == estadoMental.idPaciente);
                modelo.estadoMental = modelo.listaEstadoMental.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = estadoMental.idPaciente, tabname = "EstadoMental" });
            }
            return NotFound();
        }
    }
}
