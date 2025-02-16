using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

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

        public List<SucursalCLS> filtrarSucursal(string nombre)
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
                        cmd.Parameters.AddWithValue("@nombresucursal", nombre ?? "");

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
    }
}
