using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Obligatorio2asp.Dominio;

namespace Obligatorio2asp.Presentacion
{
    public partial class frmLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lstGeneros_Load(object sender, EventArgs e)
        {

        }

        #region AUXILIARES

        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtTitulo.Text == "" || this.txtPrecio.Text == "" || this.txtAno.Text == "" || this.lstAutor.SelectedValue == "" || this.lstGeneros.SelectedValue == "" || this.lstPais.SelectedValue == "")
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
            this.txtPrecio.Text = "";
            this.txtTitulo.Text = "";
            this.txtAno.Text = "";
            this.lstPais.SelectedIndex = -1;
            this.lstGeneros.SelectedIndex = -1;
            this.lstAutor.SelectedIndex = -1;
            this.txtComentario.Text = "";

        }
        private void listarGeneros()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstGeneros.DataSource = null;
            this.lstGeneros.DataSource = unaMunicipalidad.ListaGeneros();
            this.lstGeneros.DataBind();
        }
        private void listarPais()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstPais.DataSource = null;
            this.lstPais.DataSource = unaMunicipalidad.ListaPaises();
            this.lstPais.DataBind();

        }
        bool ordenABC = false;
        private void listar()
        {
            if (ordenABC)
            {
                ListarXABC();
            }
            else
            {
                ListarXOrden();
            }
        }
       
        private void ListarXOrden()
        {
            Municipalidad unaMunicipalidad = new Municipalidad();
            this.lstLibro.DataSource = null;
            this.lstLibro.DataSource = unaMunicipalidad.ListaLibros();
            this.lstLibro.SelectedIndex = -1;
            this.lstLibro.DataBind();
            ordenABC = false;
        }
        private void ListarXABC()
        {
            Municipalidad unaMunicipalidad = new Municipalidad();
            this.lstLibro.DataSource = null;
            this.lstLibro.DataSource = unaMunicipalidad.ListaOrdenadaLibro();
            this.lstLibro.SelectedIndex = -1;
            this.lstLibro.DataBind();
            ordenABC = true;
        }
        private void listarAutores()
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            this.lstAutor.DataSource = null;
            this.lstAutor.DataSource = unaMunicipalidad.ListaAutores();
            this.lstAutor.DataBind();


        }

        private Dominio.Autor AutorSelec()
        {
            if (this.lstAutor.SelectedValue != null)
            {
                Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();

                string CliSt = this.lstAutor.SelectedItem.ToString();
                string[] CliArr = CliSt.Split(' ');
                int Id = int.Parse(CliArr[0]);
                Autor vec = unaMunicipalidad.BuscarAutor(Id);
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


        private Genero GeneroSelect()
        {
            if (this.lstGeneros.SelectedValue != null)
            {
                Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();

                string CliSt = this.lstGeneros.SelectedItem.ToString();
                string[] CliArr = CliSt.Split(' ');
                int Id = int.Parse(CliArr[0]);
               Genero vec = unaMunicipalidad.BuscarGenero(Id);
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
        private Pais PaisSelect()
        {
            if (this.lstPais.SelectedValue != null)
            {
                Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();

                string CliSt = this.lstPais.SelectedItem.ToString();
                string[] CliArr = CliSt.Split(' ');
                int Id = int.Parse(CliArr[0]);
                Pais vec = unaMunicipalidad.BuscarPais(Id);
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

        private void cargarLibro(short pId)
        {
            Dominio.Municipalidad unaMunicipalidad = new Dominio.Municipalidad();
            Libro unLibro = unaMunicipalidad.BuscarLibro(pId);
            this.txtId.Text = unLibro.Id.ToString();
            this.txtTitulo.Text = unLibro.Titulo.ToString();
            this.txtPrecio.Text = unLibro.Precio.ToString();
            this.txtAno.Text = unLibro.Titulo.ToString();
            this.txtComentario.Text = unLibro.Comentario.ToString();

            Autor unAutor = unaMunicipalidad.BuscarAutor(unLibro.Autor.Id);
            this.lstAutor.SelectedValue = unAutor.ToString();

            Genero unGenero = unaMunicipalidad.BuscarGenero(unLibro.Genero.Id);
            this.lstGeneros.SelectedValue = unGenero.ToString();

            Pais unPais = unaMunicipalidad.BuscarPais(unLibro.Pais.Id);
            this.lstPais.SelectedValue = unPais.ToString();

        }

            #endregion
            protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void lstGeneros_Init(object sender, EventArgs e)
        {
            listarGeneros();
        }

        protected void lstPais_Init(object sender, EventArgs e)
        {
            listarPais();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!faltanDatos())
            {
                short id = Convert.ToInt16(this.txtId.Text);
                string titulo = this.txtTitulo.Text;
                string ano = this.txtAno.Text;
                double Precio = Convert.ToDouble(this.txtPrecio.Text);
                Autor Autor = this.AutorSelec();
                Genero Genero = this.GeneroSelect();
                Pais Pais = this.PaisSelect();
                string comentario = this.txtComentario.Text;

                Dominio.Libro unLibro = new Dominio.Libro(id, titulo, ano, Genero, Autor, Pais, Precio, comentario);
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                if (dominio.AltaLibro(unLibro))
                {
                    this.lblMensajes.Text = "Libro dado de alta con exito.";
                    listar();
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe libro con este Id.";
                }

            }
            else
                this.lblMensajes.Text = "Faltan datos";
        }

        protected void lstAutor_Init(object sender, EventArgs e)
        {
            listarAutores();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                Dominio.Municipalidad dominio = new Dominio.Municipalidad();
                short id = Convert.ToInt16(this.txtId.Text);
                if (dominio.BajaLibro(id))
                {
                    this.listar();
                    this.limpiar();

                    this.lblMensajes.Text = "Libro elimiado de alta con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "No existe libro con este Id.";
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
                string titulo = this.txtTitulo.Text;
                string ano = this.txtAno.Text;
                double Precio = Convert.ToDouble(this.txtPrecio.Text);
                Autor Autor = this.AutorSelec();
                Genero Genero = this.GeneroSelect();
                Pais Pais = this.PaisSelect();
                string comentario = this.txtComentario.Text;


                Libro unLibro = new Libro(id, titulo, ano, Genero, Autor, Pais, Precio, comentario);
                Municipalidad dominio = new Municipalidad();
                if (dominio.ModificarLibro(unLibro))
                {
                    this.listar();
                    this.limpiar();
                    this.lblMensajes.Text = "Libro dado modificado con exito.";
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe Libro con este Id.";
                }

            }
            else
                this.lblMensajes.Text = "Faltan Datos";
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstLibro.SelectedIndex > -1)
            {
                string linea = this.lstLibro.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarLibro(id);
                this.lstLibro.SelectedIndex = -1;
            }
            else
            {
                this.lblMensajes.Text = "Debe seleccionar un lector de la lista.";

                this.lblMensajes.Text = lstAutor.SelectedIndex.ToString() + " " + this.lstAutor.Items[0].ToString();
            }
        }

        protected void rbtnIngreso_CheckedChanged(object sender, EventArgs e)
         {
         
                ListarXOrden();
            
        }

        protected void rbtnNombre_CheckedChanged(object sender, EventArgs e)
        {
           
                ListarXABC();
            
        }

        protected void lstLibro_Init(object sender, EventArgs e)
        {
            listar();
        }
    }
}