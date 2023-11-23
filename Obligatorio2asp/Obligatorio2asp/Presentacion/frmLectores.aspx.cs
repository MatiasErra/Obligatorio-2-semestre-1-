using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio2asp.Presentacion
{

    public partial class frmLectores : System.Web.UI.Page
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
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.lblMensajes.Text = "";
            this.txtId.Focus();

        }

        private void listar()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstAutor.DataSource = null;
            this.lstAutor.DataSource = unaMunicipalidad.ListaLectores();
            this.lstAutor.DataBind();
        }

        private void cargarLector(int pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Dominio.Lector unLector = unaMunicipalidad.BuscarLector(pId);
            this.txtId.Text = unLector.Id.ToString();
            this.txtNombre.Text = unLector.Nombre.ToString();
            this.txtApellido.Text = unLector.Apellido.ToString();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lstAutor_Init(object sender, EventArgs e)
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


                Dominio.Lector unLector = new Dominio.Lector(id, nombre, apellido);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.AltaLector(unLector))
                {
                    this.lblMensajes.Text = "Lector dado de alta con exito.";
                    this.listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe Lector con este Id.";
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
                short id = Convert.ToInt16(this.txtId.Text);
                if (dominio.BajaLector(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Lector elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe Lector con este Id.";
                }
            }
            else
                this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                short id = Convert.ToInt16(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;


                Dominio.Lector unLector = new Dominio.Lector(id, nombre, apellido);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.ModificarLector(unLector))
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
                this.cargarLector(id);
                this.lstAutor.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un lector de la lista.";

                this.lblMensajes.Text = lstAutor.SelectedIndex.ToString() + " " + this.lstAutor.Items[0].ToString();
            }
        }

        protected void lstAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
