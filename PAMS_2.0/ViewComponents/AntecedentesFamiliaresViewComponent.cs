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
    public class AntecedentesFamiliaresViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public AntecedentesFamiliaresViewComponent(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaAntecedentesFamiliares = _context.AntecedentesFamiliares.Where(ant => ant.idPaciente == id);
            foreach(var item in modelo.listaAntecedentesFamiliares)
            {
                modelo.antecedentesFamiliares = item;
            }
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
        
      
    }
}
