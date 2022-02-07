using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ejercicio1.Models;
using ejercicio1.Models.Clases;
using ejercicio1.Utilities;

namespace ejercicio1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string _cadenaConexion;



        CatalogosModel catalogos;
        ClienteModel clienteM;
        PagoModel pagoM;
        ContactoModel contactoM;
        NegocioModel negocioM;
        VehiculoModel vehiculoM;

        
        public ClienteController(IConfiguration configuration)
        {
            this._cadenaConexion = configuration.GetConnectionString("ConectionString");
            this.catalogos = new CatalogosModel(_cadenaConexion);
            this.clienteM = new ClienteModel(_cadenaConexion);
            this.pagoM = new PagoModel(_cadenaConexion);
            this.contactoM = new ContactoModel(_cadenaConexion);
            this.negocioM = new NegocioModel(_cadenaConexion);
            this.vehiculoM = new VehiculoModel(_cadenaConexion);

        }
        
        public IActionResult Index() {
            ViewBag.getAllCliente = clienteM.GetAllClientes();
            return View();
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

            string valor = "S";

            if (idCliente > 0) {
                //insertar los datos de pago y contacto
                    pagoM.InsertarPago(idCliente, dataCliente.pago);

                foreach (var contacto in dataCliente.contactos)
                {
                    contactoM.InsertarContacto(idCliente, contacto);
                }

                if ( valor == dataCliente.negocio.valorNegocio)
                {
                    negocioM.InsertarNegocio(idCliente, dataCliente.negocio);
                }
                if (valor == dataCliente.vehiculo.valorVehiculo)
                {
                    vehiculoM.InsertarVehiculo(idCliente, dataCliente.vehiculo);
                }

            }


                return Json(new { });
        }

        /// <summary>
        /// se hace la consulta a la base de datos de toda la información del cliente para mostrarla en la vista #EditarCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public IActionResult EditarCliente(int idCliente)
        {
            var cliente = clienteM.GetCliente(idCliente);
            var pago = ViewBag.pago = pagoM.GetPago(idCliente);
            var vehiculo = vehiculoM.GetVehiculo(idCliente);
            var negocio = negocioM.GetNegocio(idCliente);

            if (cliente.Count > 0)
            {
                ViewBag.cliente = cliente[0];
                ViewBag.pago = (pago.Count > 0) ? pago[0] : null;
                ViewBag.contactos = JsonConvert.SerializeObject(contactoM.GetContactos(idCliente));
                
               ViewBag.vehiculo = (vehiculo.Count > 0) ? vehiculo[0] : null;
               ViewBag.negocio = (negocio.Count > 0) ? negocio[0] : null; ;

                ViewBag.tiposIdentificacion = catalogos.getAllTipoIdentificacion();
                ViewBag.tiposTarjeta = catalogos.getAllTipoTarjeta();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Cliente");
            }
        }

        /// <summary>
        /// metodo el cual optiene el json del frond y lo pasa a los metodos que les corresponde cada información 
        /// </summary>
        /// <param name="dataCliente"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ActualizarCliente([FromBody] DataCliente dataCliente)
        {
            if (dataCliente != null && dataCliente.cliente.idCliente > 0)
            {
                
                //insertar los datos actualizados 
                clienteM.ActualizarCliente(dataCliente.cliente);
                pagoM.ActualizarPago(dataCliente.cliente.idCliente, dataCliente.pago);

                foreach (var contacto in dataCliente.contactos)
                {
                    contactoM.ActualizarContacto( contacto.idCliente, contacto.idContacto);
                }

                if (dataCliente.negocio.valorNegocio.Equals("S"))
                {
                    negocioM.ActualizarNegocio(dataCliente.cliente.idCliente, dataCliente.negocio);
                }
                if (dataCliente.negocio.valorNegocio.Equals("N"))
                {
                    negocioM.EliminarNegocio(dataCliente.cliente.idCliente);
                }
                if (dataCliente.vehiculo.valorVehiculo.Equals("S"))
                {
                    vehiculoM.ActualizarVehiculo(dataCliente.cliente.idCliente, dataCliente.vehiculo);
                }
                if (dataCliente.vehiculo.valorVehiculo.Equals("N"))
                {
                    vehiculoM.EliminarVehiculo(dataCliente.cliente.idCliente);
                }

            }


            return Json(new { });
        }


        [HttpPost]
        public JsonResult EliminarCliente(int idCliente)
        {

            return Json((clienteM.EliminarCliente(idCliente)) ? Ok() : BadRequest()) ;
        }



    }
}
