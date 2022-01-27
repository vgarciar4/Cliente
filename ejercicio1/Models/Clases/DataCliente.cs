using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class DataCliente
    {
        public Cliente cliente { get; set; }
        public Pago pago { get; set; }

        public List<Contacto> contactos { get; set; }
    }
}
