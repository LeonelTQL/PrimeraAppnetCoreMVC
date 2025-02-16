using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static CapaEntidad.LaboratorioCLS;

namespace CapaDatos
{
    public class LaboratorioDAL : ConexionDAL
    {
        public List<listarLaboratorioCLS> listarLaboratorio()
        {
            List<listarLaboratorioCLS> lista = new List<listarLaboratorioCLS>();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                listarLaboratorioCLS oSucursal = new listarLaboratorioCLS()
                                {
                                    idLaboratorio = drd.GetInt32(0),
                                    nombre = drd.GetString(1),
                                    direccion = drd.GetString(2),
                                    personacontacto = drd.GetString(3)
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
        public List<FiltrarLaboratorioCLS> FiltrarLaboratorio(int idLaboratorio ,string nombre, string direccion, string personacontacto)
        {
            List<FiltrarLaboratorioCLS> lista = null;


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        // Aseguramos que los parámetros sean del tipo correcto
                        cmd.Parameters.Add("@idlaboratorio", System.Data.SqlDbType.Int).Value = idLaboratorio;
                        cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 100).Value = nombre ?? "";
                        cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 100).Value = direccion ?? "";
                        cmd.Parameters.Add("@personacontacto", System.Data.SqlDbType.VarChar, 100).Value = personacontacto ?? "";


                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            FiltrarLaboratorioCLS medCLS;
                            lista = new List<FiltrarLaboratorioCLS>();
                            while (dr.Read())
                            {
                                medCLS = new FiltrarLaboratorioCLS();
                                medCLS.idLaboratorio = dr.GetInt32(0);
                                medCLS.nombre = dr.GetString(1);
                                medCLS.direccion = dr.GetString(2);
                                medCLS.personacontacto = dr.GetString(3);
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
    }
}
