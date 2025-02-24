using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MedicamentoDAL : ConexionDAL
    {
        public List<MedicamentoCLS> listarMedicamento()
        {
            List<MedicamentoCLS> lista = new List<MedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspListarMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                MedicamentoCLS oMedicamento = new MedicamentoCLS()
                                {
                                    IIDMEDICAMENTO = drd.GetInt32(0),
                                    NOMBREMEDICAMENTO = drd.GetString(1),
                                    NOMBRELABORATORIO = drd.GetString(2),
                                    NOMBRETIPO = drd.GetString(3)
                                };
                                lista.Add(oMedicamento);
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

        public List<MedicamentoCLS> filtrarMedicamento(MedicamentoCLS obj)
        {
            List<MedicamentoCLS> lista = new List<MedicamentoCLS>();

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@idmedicamento", obj.IIDMEDICAMENTO);
                        cmd.Parameters.AddWithValue("@nombre", obj.NOMBREMEDICAMENTO ?? "");
                        cmd.Parameters.AddWithValue("@idlaboratorio", obj.IIDLABORATORIO);
                        cmd.Parameters.AddWithValue("@idtipomedicamento", obj.IIDTIPOMEDICAMENTO);

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<MedicamentoCLS>();

                            int posId = drd.GetOrdinal("IIDMEDICAMENTO");
                            int posNombre = drd.GetOrdinal("NOMBREMEDICAMENTO");
                            int posLaboratorio = drd.GetOrdinal("NOMBRELABOTARIO");
                            int posTipo = drd.GetOrdinal("NOMBRETIPO");

                            while (drd.Read())
                            {
                                MedicamentoCLS oMedicamento = new MedicamentoCLS
                                {
                                    IIDMEDICAMENTO = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId),
                                    NOMBREMEDICAMENTO = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre),
                                    NOMBRELABORATORIO = drd.IsDBNull(posLaboratorio) ? "" : drd.GetString(posLaboratorio),
                                    NOMBRETIPO = drd.IsDBNull(posTipo) ? "" : drd.GetString(posTipo)
                                };
                                lista.Add(oMedicamento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = null;
                }
            }
            return lista;
        }

        public int guardarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Medicamento(NOMBREMEDICAMENTO, IIDLABORATORIO,BHABILITADO,IIDTIPOMEDICAMENTO) VALUES (@nombremedicamento,@iidlaboratorio,1,@iidtipomedicamento)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombremedicamento", oMedicamentoCLS.NOMBREMEDICAMENTO);
                        cmd.Parameters.AddWithValue("@iidlaboratorio", oMedicamentoCLS.IIDLABORATORIO);
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", oMedicamentoCLS.IIDTIPOMEDICAMENTO);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return rpta;
        }

        public int eliminarMedicamento(int idmedicamento)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMedicamento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmedicamento", idmedicamento);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                }
            }
            return rpta;
        }
    }
}
