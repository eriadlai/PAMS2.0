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
        public IActionResult Edit(AntecedentesFamiliares oFamiliares)
        {
           
            if (ModelState.IsValid)
                {
                    _context.AntecedentesFamiliares.Update(oFamiliares);
                    _context.SaveChanges();
                    TempData["message"] = "El usuario se ha actualizado";
                    ViewModel modelo = new ViewModel();
                    modelo.listaAntecedentesFamiliares = _context.AntecedentesFamiliares.Where(ant => ant.idPaciente == oFamiliares.idPaciente);
                    modelo.Sesion = HttpContext.Session.GetString("usuario");
                    modelo.rol = HttpContext.Session.GetString("rol");
                return RedirectToAction("AntecedentesFamiliaresController","InvokeAsync",oFamiliares.idPaciente);
                }


            return NotFound();
        }
    }
}
