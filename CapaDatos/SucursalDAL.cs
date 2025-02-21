using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static CapaEntidad.LaboratorioCLS;

namespace CapaDatos
{
    public class SucursalDAL : ConexionDAL
    {
        public List<SucursalCLS> listarSucursales()
        {
            List<SucursalCLS> lista = new List<SucursalCLS>();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                SucursalCLS oSucursal = new SucursalCLS()
                                {
                                    idsucursal = drd.GetInt32(0),
                                    nombre = drd.GetString(1),
                                    direccion = drd.GetString(2)
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

        public List<SucursalCLS> recuperarSucursal(int idSucursal)
        {
            List<SucursalCLS> lista = new List<SucursalCLS>();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidsucursal", idSucursal);

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                SucursalCLS oSucursal = new SucursalCLS()
                                {
                                    idsucursal = drd.GetInt32(0),
                                    nombre = drd.GetString(1),
                                    direccion = drd.GetString(2)
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

        public List<SucursalCLS> filtrarSucursal(SucursalCLS obj)
        {
            List<SucursalCLS> lista = new List<SucursalCLS>();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", obj.nombre == null ? "" : obj.nombre);
                        cmd.Parameters.AddWithValue("@direccion", obj.direccion == null ? "" : obj.direccion);

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {

                            SucursalCLS oSucursalCLS;
                            lista = new List<SucursalCLS>();

                            int posId = drd.GetOrdinal("IIDSUCURSAL");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDireccion = drd.GetOrdinal("DIRECCION");

                            while (drd.Read())
                            {

                                oSucursalCLS = new SucursalCLS();
                                oSucursalCLS.idsucursal = drd.IsDBNull(posId) ? 0 : drd.GetInt32(0);
                                oSucursalCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(1);
                                oSucursalCLS.direccion = drd.IsDBNull(posDireccion) ? "" : drd.GetString(2);
                                lista.Add(oSucursalCLS);
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

        public int guardarSucursal(SucursalCLS oSucursalCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Sucursal (NOMBRE, DIRECCION,BHABILITADO) VALUES (@nombre, @direccion,1)", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oSucursalCLS.nombre);
                        cmd.Parameters.AddWithValue("@direccion", oSucursalCLS.direccion);

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

    }
}
