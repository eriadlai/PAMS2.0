using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers.Psicologia
{
    public class AntecedentesClinicosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public AntecedentesClinicosViewComponent(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {

            ViewModel modelo = new ViewModel();
            modelo.listaAntecedentesClinicos = _context.AntecedentesClinicos.Where(ant => ant.idPaciente == id);
            foreach (var item in modelo.listaAntecedentesClinicos) {
                modelo.antecedentesClinicos = item;
            }
            modelo.Sesion = HttpContext.Session.GetString("usuario");
            modelo.rol = HttpContext.Session.GetString("rol");
            return View(modelo);
        }
 
       
    }
}
