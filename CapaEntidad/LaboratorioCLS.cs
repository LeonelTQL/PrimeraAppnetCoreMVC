﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class LaboratorioCLS
    {
        public class listarLaboratorioCLS
        {
            public int idLaboratorio { get; set; }
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string personacontacto { get; set; }

        }
        public class FiltrarLaboratorioCLS
        {
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string personacontacto { get; set; }

        }
    }
}
