using Microsoft.AspNetCore.Mvc;
using PAMS_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAMS_2._0.Controllers.Logistica
{

    public class ProductoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        //VERIFICACIONES==================================
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifySku(string sku)
        {
            if (_context.VerifySku(sku))
            {
                return Json($"El producto con la serie: {sku} Ya existe.");
            }

            return Json(true);
        }
    }
}
