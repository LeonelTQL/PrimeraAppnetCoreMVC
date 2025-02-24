using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MedicamentoBL
    {
        public List<MedicamentoCLS> listarMedicamento()
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.listarMedicamento();
        }

        public List<MedicamentoCLS> filtrarMedicamento(MedicamentoCLS objMedicamento)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.filtrarMedicamento(objMedicamento);
        }

        public int guardarMedicamento(MedicamentoCLS obj)
        {
            MedicamentoDAL oMedicamentoDAL = new MedicamentoDAL();
            return oMedicamentoDAL.guardarMedicamento(obj);
        }

        public int eliminarMedicamento(int id)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.eliminarMedicamento(id);
        }
    }
}
