using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio2asp.Presentacion
{
    public partial class frmPaises : System.Web.UI.Page
    {
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
            this.lstPais.DataSource = null;
            this.lstPais.DataSource = unaMunicipalidad.ListaPaises();
            this.lstPais.DataBind();
        }
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.lblMensajes.Text = "";
            this.txtId.Focus();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void cargarPais(int pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Dominio.Pais unPais = unaMunicipalidad.BuscarPais(pId);
            this.txtId.Text = unPais.Id.ToString();
            this.txtNombre.Text = unPais.Nombre.ToString();
        }
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;

                Dominio.Pais unPais = new Dominio.Pais(id, nombre);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.AltaPais(unPais))
                {
                    this.lblMensajes.Text = "Pais dado de alta con exito.";
                    this.listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe pais con este Id.";
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
                if (dominio.BajaPais(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Pais elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe pais con este Id.";
                }
            }
            else
            this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                Dominio.Pais unPais = new Dominio.Pais(id, nombre);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.ModificarPais(unPais))
                {
                    this.listar();
                    this.limpiar();
                    this.lblMensajes.Text = "Pais dado modificado con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe pais con este Id.";
                }

            }
            else
            this.lblMensajes.Text = "Faltan Datos";
        }
    


    

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstPais.SelectedIndex > -1)
            {
                string linea = this.lstPais.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarPais(id);
                this.lstPais.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un pais de la lista.";

                this.lblMensajes.Text = lstPais.SelectedIndex.ToString() + " " + this.lstPais.Items[0].ToString();
            }
        }

        protected void lstPais_Init(object sender, EventArgs e)
        {
            listar();
        }
    }
}