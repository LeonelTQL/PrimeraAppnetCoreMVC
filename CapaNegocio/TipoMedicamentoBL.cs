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




        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(TipoMedicamentoCLS obj)
        {
            TipoMedicamentoDAL oTipoMedicamentoDAL = new TipoMedicamentoDAL();
            return oTipoMedicamentoDAL.filtrarTipoMedicamento(obj);
        }

        public int guardarTipoMedicamento(TipoMedicamentoCLS obj)
        {
            TipoMedicamentoDAL oTipoMedicamentoDAL = new TipoMedicamentoDAL();
            return oTipoMedicamentoDAL.guardarTipoMedicamento(obj);
        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int obj)
        {
            TipoMedicamentoDAL oTipoMedicamentoDAL = new TipoMedicamentoDAL();
            return oTipoMedicamentoDAL.recuperarTipoMedicamento(obj);
        }

        public int editarTipoMedicamento(TipoMedicamentoCLS obj)
        {
            TipoMedicamentoDAL oTipoMedicamentoDAL = new TipoMedicamentoDAL();
            return oTipoMedicamentoDAL.editarTipoMedicamento(obj);
        }
    }
}
