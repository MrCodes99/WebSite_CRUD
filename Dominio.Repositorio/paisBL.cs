using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//REFERENCIA
using Dominio.Entidades;
using Infraestructura.Data;

namespace Dominio.Repositorio
{
    public class paisBL
    {
        paisDAL pais = new paisDAL();

        public List<paisEntidad> listaPaises()
        {
            return pais.listaPaises();
        }
    }
}
