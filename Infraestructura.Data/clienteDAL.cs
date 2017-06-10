using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//REFERENCIA
using Dominio.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data
{
    public class clienteDAL
    {
        SqlConnection cn = new SqlConnection(
            "server=.; database=Negocios2017; uid=sa; pwd=amorypaz");

        public List<clienteEntidad> listado()
        {

            List<clienteEntidad> lista = new List<clienteEntidad>();

            cn.Open();

            SqlCommand cmd = new SqlCommand("USP_LISTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clienteEntidad reg = new clienteEntidad();
                reg.idcliente = dr.GetString(0);
                reg.nombrecia = dr.GetString(1);
                reg.direccion = dr.GetString(2);
                reg.idpais = dr.GetString(3);
                reg.telefono = dr.GetString(4);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

        public string Agregar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_REGISTRAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@fono", reg.telefono);

                cmd.ExecuteNonQuery();
                msj = "Registro exitoso";

            }
            catch(SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }

            return msj;
        }

        public string Actualizar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_ACTUALIZAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@pais", reg.idpais);
                cmd.Parameters.AddWithValue("@fono", reg.telefono);
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                cmd.ExecuteNonQuery();
                msj = "Registro actualizado";

            }
            catch (SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }

            return msj;
        }

        public string Eliminar(clienteEntidad reg)
        {
            string msj = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_ELIMINAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                cmd.ExecuteNonQuery();
                msj = "Registro eliminado";

            }
            catch (SqlException e)
            {
                msj = e.Message;
            }
            finally
            {
                cn.Close();
            }

            return msj;
        }

    }
}
