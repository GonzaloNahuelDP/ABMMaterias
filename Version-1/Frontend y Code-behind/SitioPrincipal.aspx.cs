using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionWeb.EstructuraModelo;

namespace AplicacionWeb
{
    public partial class SitioPrincipal : System.Web.UI.Page
    {
        private DAO dao;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dao = new DAO();
            txtCodigo.Focus();
        }

        protected void TextBoxCodigo_Changed(object sender, EventArgs e)
        {
        }

        protected void TextBoxMateria_Changed(object sender, EventArgs e)
        {
        }

        protected void TextBoxNota_Changed(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            Materia materia = dao.buscarMateriaPorCodigo(codigo);

            if (materia != null)
            {
                txtMateria.Text = materia.nombre;
                txtNota.Text = materia.nota;

                txtCodigo.Enabled = false;
                txtMateria.Enabled = true;
                txtNota.Enabled = true;

                btnBuscar.Enabled = false;
                btnCrear.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;

                lblMensaje.Text = "Materia encontrada";
                lblMensaje.Enabled = true;
            }
            else
            {
                txtCodigo.Enabled = false;
                txtMateria.Enabled = true;
                txtNota.Enabled = true;

                btnBuscar.Enabled = false;
                btnCrear.Enabled = true;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;

                lblMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("#CC0000");
                lblMensaje.Text = "No existe una materia con ese código. Puede crearla.";
                lblMensaje.Enabled = true;
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            materia.codigo = txtCodigo.Text;
            materia.nombre = txtMateria.Text;
            materia.nota = txtNota.Text;

            this.dao.crearMateria(materia);
            this.VolverPaginaALaNormalidad();

            lblMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009933");
            lblMensaje.Text = "Materia creada correctamente";
            lblMensaje.Enabled = true;

            this.actualizarTablaDeMaterias();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            materia.codigo = txtCodigo.Text;
            materia.nombre = txtMateria.Text;
            materia.nota = txtNota.Text;

            this.dao.actualizarMateria(materia);
            this.VolverPaginaALaNormalidad();

            lblMensaje.Text = "Materia actualizada correctamente";
            lblMensaje.Enabled = true;

            this.actualizarTablaDeMaterias();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            this.dao.borrarMateria(codigo);

            this.VolverPaginaALaNormalidad();

            lblMensaje.Text = "Materia eliminada correctamente";
            lblMensaje.Enabled = true;

            this.actualizarTablaDeMaterias();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.VolverPaginaALaNormalidad();
        }

        private void VolverPaginaALaNormalidad()
        {
            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtMateria.Text = "";
            txtMateria.Enabled = false;
            txtNota.Text = "";
            txtNota.Enabled = false;

            btnBuscar.Enabled = true;
            btnCrear.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            lblMensaje.Text = "";
            lblMensaje.Enabled = false;

            txtCodigo.Focus();
        }

        private void actualizarTablaDeMaterias()
        {
            DataSourceMaterias.DataBind();
            tablaDeMaterias.DataBind();
        }

    }
}