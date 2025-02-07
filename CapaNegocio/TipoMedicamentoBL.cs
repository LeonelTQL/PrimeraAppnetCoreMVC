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
    }
}
