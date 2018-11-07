using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AplicacionWeb.EstructuraModelo
{
    public class Conexion
    {
        public SqlConnection conexionSQL;
        public SqlCommand comandoSQL;
        public SqlDataReader lectorDatosSQL;

        public Conexion()
        {
            conexionSQL = new SqlConnection(
                "Data source=localhost; " +
                "Initial Catalog=materias_bd; " +
                "user id = SA; " +
                "password = gndp93");
        }
    }
}