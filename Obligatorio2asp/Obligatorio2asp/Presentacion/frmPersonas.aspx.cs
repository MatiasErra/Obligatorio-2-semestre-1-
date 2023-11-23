using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Obligatorio2asp.Presentacion
{
    public partial class frmPersonas : System.Web.UI.Page
    {

        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtNombre.Text == "" || this.txtApellido.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool FechasCorrectas()
        {
            if (this.txtNacionalidad.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        private void limpiar()
        {
            this.txtId.Text = "" ;
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtFallecido.Text = "";
            this.txtFechaDeNac.Text = "";
            this.txtNacionalidad.Text = "";
            this.lblMensajes.Text = "";
            this.txtId.Focus();

        }

        private void listar()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstAutor.DataSource = null;
            this.lstAutor.DataSource = unaMunicipalidad.ListaAutores();
            this.lstAutor.DataBind();
        }

            protected void Page_Load(object sender, EventArgs e)
        {
            listar();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string nacionalidad = this.txtNacionalidad.Text;
                string FechaDeNac = this.txtFechaDeNac.Text;
                string Fallecido = this.txtFallecido.Text;



                Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, nacionalidad, FechaDeNac, Fallecido);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.AltaAutor(unAutor))
                {
                    this.lblMensajes.Text = "Alumno dado de alta con exito.";
                    this.listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe Alumno con este Id.";
                }

            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}