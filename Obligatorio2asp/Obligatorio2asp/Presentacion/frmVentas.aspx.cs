using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2asp.Dominio;

namespace Obligatorio2asp.Presentacion
{
    public partial class frmVentas : System.Web.UI.Page
    {

        #region AUXILIARES

        private bool faltanDatos()
        {
            if (this.txtId.Text == ""  || this.lstLectores.SelectedValue == "" || this.lstLibros.SelectedValue == "" || this.dtFecha.SelectedDate == null)
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
          
            this.lstLectores.SelectedIndex = -1;
            this.lstLibros.SelectedIndex = -1;
            this.dtFecha.VisibleDate = DateTime.Today;

        }
       
        private void listarLectores()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstLectores.DataSource = null;
            this.lstLectores.DataSource = unaMunicipalidad.ListaLectores();
            this.lstLectores.DataBind();
        }
        private void listarLibros()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstLibros.DataSource = null;
            this.lstLibros.DataSource = unaMunicipalidad.ListaLibros();
            this.lstLibros.DataBind();
        }
        private void listar()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstVentas.DataSource = null;
            this.lstVentas.DataSource = unaMunicipalidad.ListaVentas();
            this.lstVentas.DataBind();
        }
        

       


        private Lector LectorSelect()
        {
            if (this.lstLectores.SelectedValue != null)
            {
                Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();

                string CliSt = this.lstLectores.SelectedItem.ToString();
                string[] CliArr = CliSt.Split(' ');
                int Id = int.Parse(CliArr[0]);
                Lector vec = unaMunicipalidad.BuscarLector(Id);
                if (vec != null)
                {
                    return vec;

                }
                else
                {
                    return null;

                }
            }
            else
            {
                return null;

            }

        }
        private Libro LibroSelect()
        {
            if (this.lstLibros.SelectedValue != null)
            {
                Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();

                string CliSt = this.lstLibros.SelectedItem.ToString();
                string[] CliArr = CliSt.Split(' ');
                short Id = short.Parse(CliArr[0]);
                Libro vec = unaMunicipalidad.BuscarLibro(Id);
                if (vec != null)
                {
                    return vec;

                }
                else
                {
                    return null;

                }
            }
            else
            {
                return null;

            }

        }

        private void cargarVenta(short pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Venta unaVenta = unaMunicipalidad.BuscarVenta(pId);
            this.txtId.Text = unaVenta.Id.ToString();
            this.dtFecha.SelectedDate = unaVenta.FechaVen;

          

            Lector unLector = unaMunicipalidad.BuscarLector(unaVenta.Lector.Id);
            this.lstLectores.SelectedValue = unLector.ToString();

            Libro unLibro = unaMunicipalidad.BuscarLibro(unaVenta.Libro.Id);
            this.lstLibros.SelectedValue = unLibro.ToString();

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstVentas.SelectedIndex > -1)
            {
                string linea = this.lstVentas.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarVenta(id);
                this.lstVentas.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un lector de la lista.";

                this.lblMensajes.Text = lstVentas.SelectedIndex.ToString() + " " + this.lstVentas.Items[0].ToString();
            }
        }

       
        protected void lstLibros_Init(object sender, EventArgs e)
        {
            listarLibros();
        }

        protected void lstLectores_Init(object sender, EventArgs e)
        {
            listarLectores();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!faltanDatos())
            {
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                short id = Convert.ToInt16(this.txtId.Text);
                DateTime fecha = this.dtFecha.SelectedDate;
             
                Lector lector= this.LectorSelect();
                Libro libro= this.LibroSelect();
               
                int autorId = libro.Autor.Id;
             
                
               
                Dominio.Venta unaVenta= new Dominio.Venta(id, fecha, libro, lector);
                
                if (dominio.Altavent(unaVenta))
                {
                    
                    this.lblMensajes.Text = "Venta dado de alta con exito.";
                    this.listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe venta con este Id.";
                }

            }
            else
                this.lblMensajes.Text = "Faltan datos";
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                short id = Convert.ToInt16(this.txtId.Text);
                if (dominio.Bajavent(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Venta elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe venta con este Id.";
                }
            }
            else
                this.lblMensajes.Text = "Faltan Datos";
        }

        protected void lstVentas_Init(object sender, EventArgs e)
        {
            listar();
        }
    }
}