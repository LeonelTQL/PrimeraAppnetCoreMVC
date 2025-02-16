using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class TipoMedicamentoBL
    {
        public List<TipoMedicamentoCLS> listarMedicamento()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();

            return obj.listarTipoMedicamento();
        }

        public void eliminarMed(int id)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            obj.EliminarMedicamento(id);
        }


        public List<FiltrarMedicamentoCLS> filtrarMedicamento(int idMed, string nombre, int idLab, int idTip)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.FiltrarMedicamento(idMed, nombre, idLab, idTip);
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string descripcion)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.filtrarTipoMedicamento(descripcion);
        }
    }
}
