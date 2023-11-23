using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio2asp.Presentacion
{
    public partial class frmEstadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsulta1_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            if (municipalidad.Recaudacion() != 0)
            {
                lblConsulta1.Text = "";
                this.lblConsulta1.Text = "La recaudacion total fue: " + Convert.ToString(municipalidad.Recaudacion());
               

            }
            else
            {
                lblConsulta1.Text = "No hay recaudacion";
            }
        }

        protected void btnConsulta3_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            municipalidad.IngresoCant();
            this.lstConsulta3.DataSource = null;
            this.lstConsulta3.DataSource = municipalidad.AutorConMasLibrosVend();
            this.lstConsulta3.DataBind();
           
           
        }
        protected void btnConsulta4_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            municipalidad.IngresoCantLib();
            this.lstConsulta4.DataSource = null;
            this.lstConsulta4.DataSource = municipalidad.LibroConMasVent();
            this.lstConsulta4.DataBind();
        }

        
    protected void btnConsulta5_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            string Nombre = this.txtNombre.Text;
            this.lstConsulta5.DataSource = null;
            List<Dominio.Venta> unVenta = municipalidad.LectorDadoNom(Nombre);
            if (unVenta.Count != 0)
            {
                this.lstConsulta5.DataSource = null;
                this.lstConsulta5.DataSource = municipalidad.LectorDadoNom(Nombre);
                lstConsulta5.DataBind();
            }
            else
            {
                this.lstConsulta5.DataSource = null;
                this.lstConsulta5.Items.Remove("No hay compras de este lector");
                this.lstConsulta5.Items.Add("No hay compras de este lector");
            }
        }

        protected void btnConsulta6_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            municipalidad.IngresoCantPais();
            this.lstConsulta6.DataSource = null;
            this.lstConsulta6.DataSource = municipalidad.PaisConMasPub();
            this.lstConsulta6.DataBind();
        }

        protected void btnConsulta7_Click(object sender, EventArgs e)
        {
            Dominio.Municipalidad municipalidad = new Dominio.Municipalidad();
            string Nombre = this.txtGenero.Text;
           
            List<Dominio.Libro> unLibro = municipalidad.LibroDadoXGenero(Nombre);
            if(unLibro.Count!=0)
            {
                this.lstConsulta7.DataSource = null;
                this.lstConsulta7.DataSource = municipalidad.LibroDadoXGenero(Nombre);
                lstConsulta7.DataBind();
            }
            else
            {
                this.lstConsulta7.DataSource = null;
                this.lstConsulta7.Items.Remove("No hay libro/s de este genero");
                this.lstConsulta7.Items.Add("No hay libro/s de este genero");
            }

        }
    }
}