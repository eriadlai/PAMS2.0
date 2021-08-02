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
    public class CirSocialController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CirSocialController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CirculoSocial circuloSocial)
        {
            if (ModelState.IsValid)
            {
                _context.CirculoSocial.Update(circuloSocial);
                _context.SaveChanges();
                TempData["message"] = "Los datos se han actualizado";
                ViewModel modelo = new ViewModel();
                modelo.listaCirculoSocial = _context.CirculoSocial.Where(ant => ant.idPaciente == circuloSocial.idPaciente);
                modelo.circuloSocial = modelo.listaCirculoSocial.First();
                modelo.Sesion = HttpContext.Session.GetString("usuario");
                modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("DetallesGenerales", "Pacientes", new { id = circuloSocial.idPaciente, tabname = "CirculoSocial" });
            }
            return NotFound();
        }
    }
}
