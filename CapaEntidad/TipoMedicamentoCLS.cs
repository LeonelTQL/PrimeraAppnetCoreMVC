namespace CapaEntidad
{
    public class TipoMedicamentoCLS
    {
        public int idMedicamento {  get; set; }
        public string nombre { get; set; } = "";
        public string descripcion { get; set; }
    }

    public class FiltrarMedicamentoCLS
    {
        public int idMedicamento { get; set; }
        public string nombre { get; set; }
        public string idLaboratorio { get; set; }
        public string idTipoMedicamento { get; set; }

    }
}
