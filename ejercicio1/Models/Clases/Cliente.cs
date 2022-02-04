using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class Cliente
    {
  
        public int idCliente { get; set; }

        public int idTipoIdentificacion { get; set; }
        public int nit { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public int numeroIdentificacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
        public string ?descripcion { get; set; } //DESCRIPCION DEL TIPO DE IDENTIFICACION
    }
}
