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
        ClienteModel clienteM;
        PagoModel pagoM;
        ContactoModel contactoM;

        public ClienteController(IConfiguration configuration)
        {
            this._cadenaConexion = configuration.GetConnectionString("ConectionString");
            this.catalogos = new CatalogosModel(_cadenaConexion);
            this.clienteM = new ClienteModel(_cadenaConexion);
            this.pagoM = new PagoModel(_cadenaConexion);
            this.contactoM = new ContactoModel(_cadenaConexion);

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
                 int idCliente = clienteM.InsertarCliente(dataCliente.cliente);


            if (idCliente > 0) {
                //insertar los datos de pago y contacto
                    pagoM.InsertarPago(idCliente, dataCliente.pago);

                foreach (var contacto in dataCliente.contactos)
                {
                    contactoM.InsertarContacto(idCliente, contacto);
                }

            }


                return Json(new { });
        }

    }
}
