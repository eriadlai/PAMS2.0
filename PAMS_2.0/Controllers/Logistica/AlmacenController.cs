using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlmacenController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //VERIFICACIONES===========================
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyDireccion(string direccion)
        {
            if (_context.VerifyDireccion(direccion))
            {
                return Json($"Un almacen con la direccion: {direccion} Ya existe.");
            }

            return Json(true);
        }
    }
}
