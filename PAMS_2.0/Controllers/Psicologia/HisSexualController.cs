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
    public class HisSexualController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HisSexualController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Edit(HistorialSexual historialSexual)
        {
            if (ModelState.IsValid)
            {
                var paciente = _context.Paciente.Find(historialSexual.idPaciente);
                paciente.ultimaActualizacion = DateTime.Now;
                _context.Paciente.Update(paciente);

                _context.HistorialSexual.Update(historialSexual);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaHistorialSexual = _context.HistorialSexual.Where(ant => ant.idPaciente == historialSexual.idPaciente);
                modelo.historialSexual = modelo.listaHistorialSexual.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = historialSexual.idPaciente, tabname = "HistorialSexual" });
            }
            return View();
        }
    }
}
