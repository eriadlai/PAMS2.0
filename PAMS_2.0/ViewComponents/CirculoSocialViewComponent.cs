using PAMS_2._0.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PAMS_2._0.ViewComponents
{
    public class CirculoSocialViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CirculoSocialViewComponent(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            ViewModel modelo = new ViewModel();
            modelo.listaCirculoSocial = _context.CirculoSocial.Where(ant => ant.idPaciente == id);
            foreach (var item in modelo.listaCirculoSocial)
            {
                modelo.circuloSocial = item;
            }
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
    }
}
