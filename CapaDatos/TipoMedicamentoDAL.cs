﻿using CapaEntidad;
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

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(TipoMedicamentoCLS obj)
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
                        cmd.Parameters.AddWithValue("@nombreTMedicamento", obj.nombre == null ? "" : obj.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", obj.descripcion == null ? "" : obj.descripcion);

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            TipoMedicamentoCLS oTipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();

                            int posId = drd.GetOrdinal("IIDTIPOMEDICAMENTO");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");


                            while (drd.Read())
                            {
                                oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                                oTipoMedicamentoCLS.idMedicamento = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoMedicamentoCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oTipoMedicamentoCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oTipoMedicamentoCLS);

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
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TipoMedicamento(NOMBRE,DESCRIPCION,BHABILITADO) VALUES (@nombre, @descripcion,1)", cn))
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


        public TipoMedicamentoCLS recuperarTipoMedicamento(int idMedicamento)
        {
            TipoMedicamentoCLS oTipoMedicamentoCLS = null;


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO as idMedicamento, NOMBRE, DESCRIPCION " +
     "FROM TipoMedicamento WHERE BHABILITADO = 1 AND IIDTIPOMEDICAMENTO = @iidtipomedicamento", cn))

                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", idMedicamento);

                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {


                            while (drd.Read())
                            {
                                oTipoMedicamentoCLS = new TipoMedicamentoCLS();
                                oTipoMedicamentoCLS.idMedicamento = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oTipoMedicamentoCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                oTipoMedicamentoCLS.descripcion = drd.IsDBNull(2) ? "" : drd.GetString(2);

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    oTipoMedicamentoCLS = null;

                }
            }
            return oTipoMedicamentoCLS;
        }


        public int editarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE TipoMedicamento SET NOMBRE = @nombre, DESCRIPCION = @descripcion WHERE IIDTIPOMEDICAMENTO = @iidtipomedicamento", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", oTipoMedicamentoCLS.idMedicamento);
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