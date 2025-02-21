using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoMedicamentoDAL : ConexionDAL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS >lista = new List<TipoMedicamentoCLS>();

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
                                oTipoMedicamentoCLS.nombre = drd.IsDBNull(1) ?  "" : drd.GetString(1);
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

        public List<FiltrarMedicamentoCLS> FiltrarMedicamento(int idMed, string nombre, int idLab, int idTip)
        {
            List<FiltrarMedicamentoCLS> lista = null;
            IConfigurationBuilder cfg = new ConfigurationBuilder();
            cfg.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = cfg.Build();
            var cadenaDato = root.GetConnectionString("cn");

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        // Aseguramos que los parámetros sean del tipo correcto
                        cmd.Parameters.Add("@idmedicamento", System.Data.SqlDbType.Int).Value = idMed;
                        cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 100).Value = nombre ?? "";
                        cmd.Parameters.Add("@idlaboratorio", System.Data.SqlDbType.Int).Value = idLab;
                        cmd.Parameters.Add("@idtipomedicamento", System.Data.SqlDbType.Int).Value = idTip;

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            FiltrarMedicamentoCLS medCLS;
                            lista = new List<FiltrarMedicamentoCLS>();
                            while (dr.Read())
                            {
                                medCLS = new FiltrarMedicamentoCLS();
                                medCLS.idMedicamento = dr.GetInt32(0);
                                medCLS.nombre = dr.GetString(1);
                                medCLS.idLaboratorio = dr.IsDBNull(1) ? "" : dr.GetString(2);
                                medCLS.idTipoMedicamento = dr.GetString(3);
                                lista.Add(medCLS);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al filtrar medicamentos: " + ex.Message);
                }
            }
            return lista;
        }

        public void EliminarMedicamento(int id)
        {
            IConfigurationBuilder cfg = new ConfigurationBuilder();
            cfg.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = cfg.Build();
            var cadenaDato = root.GetConnectionString("cn");

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmedicamento", id);

                        cmd.ExecuteNonQuery();

                    }

                }
                catch (Exception)
                {

                }
            }
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string descripcion)
        {
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@textoBusqueda", descripcion ?? "" );

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                TipoMedicamentoCLS oSucursal = new TipoMedicamentoCLS()
                                {
                                    idMedicamento = drd.GetInt32(0),
                                    nombre = drd.GetString(1),
                                    descripcion = drd.GetString(2)
                                };
                                lista.Add(oSucursal);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
                }
            }
            return lista;
        }


        public int guardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO, NOMBRE,DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO =1", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oTipoMedicamentoCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoMedicamentoCLS.descripcion);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
            }
            return rpta;
        }
    }
}