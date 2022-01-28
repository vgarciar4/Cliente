using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class Negocio
    {
        public string valorNegocio { get; set; }
        public int ?idNegocio { get; set; }
        public int ?idCliente { get; set; }
        public int ?nitNegocio { get; set; }
        public string ?nombreNegocio { get; set; }
        public string ?direccionNegocio { get; set; }
        public string ?telefonoNegocio { get; set; }
        public DateTime ?fechaCreacion { get; set; }
        public string ?estado { get; set; }
    }
}
