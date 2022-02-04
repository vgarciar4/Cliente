using ejercicio1.Models.Clases;
using ejercicio1.Utilities;
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

        Funciones funciones = new Funciones();
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
        /// <summary>
        /// optiene los contactos de un cliente por medio del idCliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public List<Contacto> GetContactos(int idCliente)
        {

            string respuesta;
            DataTable dt = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetContacto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dt);

                EliminarContacto(idCliente);

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return funciones.ConvertDataTableToList<Contacto>(dt);

        }
        public void ActualizarContacto(int idCliente, int idContacto)
        {


            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_ActualizarContacto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@idContacto", SqlDbType.Int).Value = idContacto;

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
        public void EliminarContacto(int idCliente)
        {


            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_EliminarContacto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

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

            return ;

        }
    }
}

