using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoMedicamentoDAL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS >lista = new List<TipoMedicamentoCLS>();

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var cadenaDato = root.GetConnectionString("cn");

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO, NOMBRE,DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO =1", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if(drd != null)
                        {
                            TipoMedicamentoCLS oTipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (drd.Read()) 
                            { 
                                oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                                oTipoMedicamentoCLS.idMedicamento = drd.GetInt32(0);
                                oTipoMedicamentoCLS.nombre = drd.GetString(1);
                                oTipoMedicamentoCLS.descripcion = drd.GetString(2);
                                lista.Add(oTipoMedicamentoCLS);
                            }

                        }
                    }
                }
                catch(Exception) {
                    cn.Close();
                    lista = null;
                }
            }
            return lista;
        }

        //public List<TipoMedicamentoCLS> listarTipoMedicamento()
        //{
        //    List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();
        //    lista.Add(new TipoMedicamentoCLS
        //    {
        //        idMedicamento = 1,
        //        nombre = "Analgésico",
        //        descripcion = "Desc 1"
        //    });
        //    lista.Add(new TipoMedicamentoCLS
        //    {
        //        idMedicamento = 2,
        //        nombre = "Cannabis",
        //        descripcion = "Desc 1"
        //    });
        //    lista.Add(new TipoMedicamentoCLS
        //    {
        //        idMedicamento = 3,
        //        nombre = "Vitamina",
        //        descripcion = "Desc 1"
        //    });
        //    return lista;
        //}
    }
}