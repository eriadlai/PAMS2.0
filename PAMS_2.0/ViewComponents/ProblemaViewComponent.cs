using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.ViewComponents
{
    public class ProblemaViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ProblemaViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaProblema = _context.Problema.Where(ant => ant.idPaciente == id);
            foreach (var item in modelo.listaProblema)
            {
                modelo.problema = item;
            }
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
    }
}
