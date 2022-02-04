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
    public class VehiculoModel
    {

        private readonly string cadenaConexion;

        Funciones funciones = new Funciones();
        public VehiculoModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarVehiculo(int IdCliente, Vehiculo insertarVehiculo)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@marcaVehiculo", SqlDbType.VarChar).Value = insertarVehiculo.marcaVehiculo;
                cmd.Parameters.Add("@modeloVehiculo", SqlDbType.Int).Value = insertarVehiculo.modeloVehiculo;
                cmd.Parameters.Add("@lineaVehiculo", SqlDbType.VarChar).Value = insertarVehiculo.lineaVehiculo;
                cmd.Parameters.Add("@costoAproVehiculo", SqlDbType.Decimal).Value = insertarVehiculo.costoAproVehiculo;


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
        public void ActualizarVehiculo(int idCliente, Vehiculo actualizarVehiculo)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_ActualizarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = actualizarVehiculo.idCliente;
                cmd.Parameters.Add("@marcaVehiculo", SqlDbType.VarChar).Value = actualizarVehiculo.marcaVehiculo;
                cmd.Parameters.Add("@modeloVehiculo", SqlDbType.Int).Value = actualizarVehiculo.modeloVehiculo;
                cmd.Parameters.Add("@lineaVehiculo", SqlDbType.VarChar).Value = actualizarVehiculo.lineaVehiculo;
                cmd.Parameters.Add("@costoAproVehiculo", SqlDbType.Decimal).Value = actualizarVehiculo.costoAproVehiculo;


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
        public List<Vehiculo> GetVehiculo(int idCliente)
        {

            string respuesta;
            DataTable dt = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dt);

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

            return funciones.ConvertDataTableToList<Vehiculo>(dt);

        }

        public bool EliminarVehiculo(int idCliente)
        {
            bool resp;

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_EliminarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;

                resp = true;

            }
            catch (Exception ex)
            {
                resp = false;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return resp;

        }
    }
}

