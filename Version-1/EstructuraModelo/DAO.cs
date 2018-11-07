using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AplicacionWeb.EstructuraModelo
{
    public class DAO
    {
        private Conexion conexion;

        public DAO()
        {
            this.conexion = new Conexion();
        }

        //Operaciones CRUD (Create, Read, Update, Delete)
        
        //Create (Insert)
        public void crearMateria(Materia materia)
        {
            String insert = "insert into materias values('"+materia.codigo+"','"+materia.nombre+"','"+materia.nota+"')";
            this.ejecutarComando(insert);
        }

        //Read (Select)
        public Materia buscarMateriaPorCodigo(String codigo)
        {
            Materia materiaEncontrada = null;
            String select = "select * from materias where codigo = '"+codigo+"'";

            this.conexion.conexionSQL.Open();
            this.conexion.comandoSQL = new SqlCommand(select, this.conexion.conexionSQL);

            this.conexion.lectorDatosSQL = this.conexion.comandoSQL.ExecuteReader();

            //Encuentra una materia o ninguna
            if(this.conexion.lectorDatosSQL.Read())
            {
                materiaEncontrada = new Materia();
                materiaEncontrada.codigo = this.conexion.lectorDatosSQL[0].ToString(); //codigo
                materiaEncontrada.nombre = this.conexion.lectorDatosSQL[1].ToString(); //nombre
                materiaEncontrada.nota = this.conexion.lectorDatosSQL[2].ToString(); //nota
            }

            this.conexion.conexionSQL.Close();

            return materiaEncontrada;
        }

        //Update (Update)
        public void actualizarMateria(Materia materia)
        {
            String update = "update materias set nombre = '"+materia.nombre+"', nota = '"+materia.nota+"' where codigo = '"+materia.codigo+"'";
            this.ejecutarComando(update);
        }

        //Delete (Delete)
        public void borrarMateria(String codigo)
        {
            String delete = "delete from materias where codigo = '"+codigo+"'";
            this.ejecutarComando(delete);
        }

        //Insert, Update, Delete
        private void ejecutarComando(String comandoSQL)
        {
            this.conexion.conexionSQL.Open();
            this.conexion.comandoSQL = new SqlCommand(comandoSQL, this.conexion.conexionSQL);

            this.conexion.comandoSQL.ExecuteNonQuery();
            this.conexion.conexionSQL.Close();
        }
    }
}