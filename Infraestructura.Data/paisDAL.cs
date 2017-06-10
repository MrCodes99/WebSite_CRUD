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
    public class paisDAL
    {
        SqlConnection cn = new SqlConnection(
            "server=.; database=Negocios2017; uid=sa; pwd=amorypaz");

        public List<paisEntidad> listaPaises()
        {
            List<paisEntidad> lista = new List<paisEntidad>();

            cn.Open();

            SqlCommand cmd = new SqlCommand("USP_LISTARPAISES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                paisEntidad reg = new paisEntidad();
                reg.idpais = dr.GetString(0);
                reg.nombrepais = dr.GetString(1);

                lista.Add(reg);
            }
            dr.Close();
            cn.Close();

            return lista;
        }
        

    }
}
