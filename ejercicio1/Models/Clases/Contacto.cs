using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class Contacto
    {
        public int idContacto { get; set; }
        public int idCliente { get; set; }
        public string tipo { get; set; }
        public string contacto { get; set; }
        public string principal { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    }
}
