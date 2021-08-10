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
    public class AntFamiliaresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AntFamiliaresController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AntecedentesFamiliares antecedentesFamiliares)
        {
           
            if (ModelState.IsValid)
            {
                var paciente = _context.Paciente.Find(antecedentesFamiliares.idPaciente);
                paciente.ultimaActualizacion = DateTime.Now;
                _context.Paciente.Update(paciente);

                _context.AntecedentesFamiliares.Update(antecedentesFamiliares);
                    _context.SaveChanges();
                    TempData["message"] = "Los datos se han actualizado";
                    ViewModel modelo = new ViewModel();
                   modelo.listaAntecedentesFamiliares = _context.AntecedentesFamiliares.Where(ant => ant.idPaciente == antecedentesFamiliares.idPaciente);
                modelo.antecedentesFamiliares = modelo.listaAntecedentesFamiliares.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                   modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes",new { id=antecedentesFamiliares.idPaciente,tabname="AntecedentesFamiliares"});
            }


            return NotFound();
        }
    }
}
