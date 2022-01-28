using ejercicio1.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models
{
    public class ContactoModel
    {
        private readonly string cadenaConexion;
        public ContactoModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarContacto(int IdCliente, Contacto insertarContacto)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarContacto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idNewCliente = new SqlParameter("@idCliente", SqlDbType.Int);
                idNewCliente.Direction = ParameterDirection.ReturnValue;


                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = insertarContacto.tipo;
                cmd.Parameters.Add("@contacto", SqlDbType.VarChar).Value = insertarContacto.contacto;
                cmd.Parameters.Add("@principal", SqlDbType.VarChar).Value = insertarContacto.principal;


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

