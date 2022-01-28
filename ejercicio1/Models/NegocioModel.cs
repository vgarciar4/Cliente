using ejercicio1.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models
{
    public class NegocioModel
    {

        private readonly string cadenaConexion;
        public NegocioModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarNegocio(int IdCliente, Negocio insertarNegocio)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarNegocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@nitNegocio", SqlDbType.Int).Value = insertarNegocio.nitNegocio;
                cmd.Parameters.Add("@nombreNegocio", SqlDbType.VarChar).Value = insertarNegocio.nombreNegocio;
                cmd.Parameters.Add("@direccionNegocio", SqlDbType.VarChar).Value = insertarNegocio.direccionNegocio;
                cmd.Parameters.Add("@telefonoNegocio", SqlDbType.Int).Value = insertarNegocio.telefonoNegocio;


                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;



            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return;

        }
    }
}

