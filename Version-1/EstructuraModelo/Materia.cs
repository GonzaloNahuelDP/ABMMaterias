using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.EstructuraModelo
{
    public class Materia
    {
        public String codigo;
        public String nombre;
        public String nota;

        public String Codigo
        {
            get { return this.codigo; }
            set { codigo = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Nota
        {
            get { return nota; }
            set { nota = value; }
        }
    }
}