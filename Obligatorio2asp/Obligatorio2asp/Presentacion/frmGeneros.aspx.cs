using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio2asp.Presentacion
{
    public partial class frmGeneros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtNombre.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void listar()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstGeneros.DataSource = null;
            this.lstGeneros.DataSource = unaMunicipalidad.ListaGeneros();
            this.lstGeneros.DataBind();
        }
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.lblMensajes.Text = "";
            this.txtId.Focus();
        }

        private void cargarGenero(int pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Dominio.Genero unGenero = unaMunicipalidad.BuscarGenero(pId);
            this.txtId.Text = unGenero.Id.ToString();
            this.txtNombre.Text = unGenero.Nombre.ToString();
        }

            protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;

                Dominio.Genero unGenero = new Dominio.Genero(id, nombre);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.AltaGenero(unGenero))
                {
                    this.lblMensajes.Text = "Genero dado de alta con exito.";
                    this.listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe Genero con este Id.";
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
                if (dominio.BajaGenero(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Genero elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe genero con este Id.";
                }
            }
            else
                this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstGeneros.SelectedIndex > -1)
            {
                string linea = this.lstGeneros.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarGenero(id);
                this.lstGeneros.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un genero de la lista.";

                this.lblMensajes.Text = lstGeneros.SelectedIndex.ToString() + " " + this.lstGeneros.Items[0].ToString();
            }
        }

        protected void lstGeneros_Init(object sender, EventArgs e)
        {
            listar();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                Dominio.Genero unGenero = new Dominio.Genero(id, nombre);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.ModificarGenero(unGenero))
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
    }
}