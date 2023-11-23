using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Obligatorio2asp.Presentacion
{
    public partial class frmPersonas : System.Web.UI.Page
    {

        #region AUXILIARES
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

        private void cargarAutor(int pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Dominio.Autor unAutor= unaMunicipalidad.BuscarAutor(pId);
            this.txtId.Text = unAutor.Id.ToString();
            this.txtNombre.Text = unAutor.Nombre.ToString();
            this.txtApellido.Text = unAutor.Apellido.ToString();
            this.txtFallecido.Text = unAutor.FechaDeF.ToString();
            this.txtFechaDeNac.Text = unAutor.FechaDeN.ToString();
            this.txtNacionalidad.Text = unAutor.Nacionalidad.ToString();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
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
            else
            this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                int id = Convert.ToInt16(this.txtId.Text);
                if (dominio.BajaAutor(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Autor elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe Alumno con este Id.";
                }
            }
            else
            this.lblMensajes.Text = "Faltan Datos";
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string nacionalidad = this.txtNacionalidad.Text;
                string FechaDeNac = this.txtFechaDeNac.Text;
                string Fallecido = this.txtFallecido.Text;
                Dominio.Autor autor = dominio.BuscarAutor(id);
                int cantidad = autor.LibrosVend;

                



                Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, nacionalidad, FechaDeNac, Fallecido);
                
                if (dominio.ModificarAutor(unAutor))
                {
                    this.listar();
                    this.limpiar();
                    this.lblMensajes.Text = "Autor dado modificado con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe Autor con este Id.";
                }

            }
            else
            this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

            this.limpiar();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstAutor.SelectedIndex > -1)
            {
                string linea = this.lstAutor.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarAutor(id);
                this.lstAutor.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un autor de la lista.";

                this.lblMensajes.Text = lstAutor.SelectedIndex.ToString() + " " + this.lstAutor.Items[0].ToString();
            }
        }

        protected void lstAutor_Init(object sender, EventArgs e)
        {

            listar();
        }

     
    }
}