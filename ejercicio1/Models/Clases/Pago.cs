using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class Pago
    {
        public int idPago { get; set; }
        public int idTipoTarjeta { get; set; }
        public int idCliente { get; set;  }
        public int  numeroTarjeta { get; set; }
        public DateTime vencimiento { get; set; }
        public int ccv { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    }
}
