﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class TipoIdentificacion
    {
        public int idTipoIdentificacion { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string estado { get; set; }
    }
}
