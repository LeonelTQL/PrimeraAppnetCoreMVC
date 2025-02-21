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
        public List<listarLaboratorioCLS> FiltrarLaboratorio(listarLaboratorioCLS obj)
        {
            List<listarLaboratorioCLS> lista = null;


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
              
                        cmd.Parameters.AddWithValue("@nombre", obj.nombre == null ? "": obj.nombre);
                        cmd.Parameters.AddWithValue("@direccion", obj.direccion == null ? "" : obj.direccion);
                        cmd.Parameters.AddWithValue("@personacontacto", obj.personacontacto == null ? "" : obj.personacontacto);


                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            listarLaboratorioCLS olaboratorioCLS;
                            lista = new List<listarLaboratorioCLS>();

                            int posId = dr.GetOrdinal("IIDLABORATORIO");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDireccion = dr.GetOrdinal("DIRECCION");
                            int posPersonaContacto = dr.GetOrdinal("PERSONACONTACTO");

                            while (dr.Read())
                            {
                                olaboratorioCLS = new listarLaboratorioCLS();
                                olaboratorioCLS.idLaboratorio = dr.IsDBNull(posId)? 0: dr.GetInt32(0);
                                olaboratorioCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(1);
                                olaboratorioCLS.direccion = dr.IsDBNull(posDireccion) ? "" : dr.GetString(2);
                                olaboratorioCLS.personacontacto = dr.IsDBNull(posPersonaContacto) ? "" : dr.GetString(3);
                                lista.Add(olaboratorioCLS);
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
