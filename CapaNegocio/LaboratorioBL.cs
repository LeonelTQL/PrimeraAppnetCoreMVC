using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.LaboratorioCLS;

namespace CapaNegocio
{
    public class LaboratorioBL
    {

        public List<listarLaboratorioCLS> listarLaboratorio()
        {
            LaboratorioDAL obj = new LaboratorioDAL();

            return obj.listarLaboratorio();
        }
        public List<FiltrarLaboratorioCLS> filtrarLaboratorio(int idLaboratorio ,string nombre, string direccion, string personacontacto)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.FiltrarLaboratorio(idLaboratorio,nombre,direccion,personacontacto);
        }
    }
}
