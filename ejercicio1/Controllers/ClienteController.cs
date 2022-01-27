using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejercicio1.Models;
using ejercicio1.Models.Clases;

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

        public JsonResult InsertCliente([FromBody] DataCliente dataCliente)
        { 
       
        
                //
                //insertar cliente
                // int id = clienteM.InsertarCliente(dataCliente);



                return Json(new object());
        }

    }
}
