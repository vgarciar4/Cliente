using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejercicio1.Models;

namespace ejercicio1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string _cadenaConexion;

        CatalogosModel catalogos;

        public ClienteController(IConfiguration configuration)
        {
            this._cadenaConexion = configuration.GetConnectionString("ConectionString");
            this.catalogos = new CatalogosModel(_cadenaConexion);
        }


        public IActionResult NuevoUsuario()
        {
            ViewBag.tiposIdentificacion = catalogos.getAllTipoIdentificacion();
            ViewBag.tiposTarjeta = catalogos.getAllTipoTarjeta();
            return View();
        }

        [HttpPost]
        public ActionResult ClienteSubmit(ejercicio1.Models.Clases.Cliente cliente)
        {
            System.Threading.Thread.Sleep(2000);  /*simulating slow connection*/

            /*Do something with object person*/


            return Json(new { msg = "Successfully added " + cliente.primerNombre});
        }
    }
}
