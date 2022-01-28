using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class Vehiculo
    {
        public string valorVehiculo { get; set; }
        public int ?idVehiculo { get; set; }
        public int ?idCliente { get; set; }
        public string ?marcaVehiculo { get; set; }
        public int ?modeloVehiculo { get; set; }
        public string ?lineaVehiculo { get; set; }
        public decimal ?costoAproVehiculo { get; set; }
        public DateTime ?fechaCreacion { get; set; }
        public string ?estado { get; set; }
    }
}
 