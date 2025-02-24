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
        public List<listarLaboratorioCLS> filtrarLaboratorio(listarLaboratorioCLS objLaboratorio)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.FiltrarLaboratorio(objLaboratorio);
        }

        public int guardarLaboratorio(listarLaboratorioCLS obj)
        {
            LaboratorioDAL oLaboratorioDAL = new LaboratorioDAL();
            return oLaboratorioDAL.guardarLaboratorio(obj);
        }
    }
}
