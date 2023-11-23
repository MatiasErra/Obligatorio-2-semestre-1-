using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio2asp.Persistencia;

namespace Obligatorio2asp.Dominio
{
    class Municipalidad
    {
        public Municipalidad()
        {
            _persistencia = new ControladorPersistencia();
            _listaAutores = _persistencia.ListaAutores();
            _listaGeneros = _persistencia.ListaGenero();
            _listaPaises = _persistencia.ListaPaises();
            _listaLectores = _persistencia.ListaLectores();
        }
        private static List<Venta> _listaVentas = new List<Venta>();
        private static List<Libro> _listaLibros = new List<Libro>();
        private static List<Lector> _listaLectores = new List<Lector>();
        private static List<Autor> _listaAutores = new List<Autor>();
        private static List<Genero> _listaGeneros = new List<Genero>();
        private static List<Pais> _listaPaises = new List<Pais>();
        private static ControladorPersistencia _persistencia;

        public List<Venta> ListaVentas()
        {
            return _listaVentas;
        }
        public List<Libro> ListaLibros()
        {
            return _listaLibros;
        }
        public List<Lector> ListaLectores()
        {
            return _listaLectores;
        }
        public List<Autor> ListaAutores()
        {
            return _listaAutores;
        }
        public List<Genero> ListaGeneros()
        {
            return _listaGeneros;
        }
        public List<Pais> ListaPaises()
        {
            return _listaPaises;
        }

        #region ABM Ventas
        public Venta BuscarVenta(short pId)
        {
            foreach (Venta unVenta in _listaVentas)
            {
                if (unVenta.Id == pId)
                    return unVenta;
            }
            return null;

        }



        public bool Altavent(Venta pVenta)
        {
            Venta unVenta = BuscarVenta(pVenta.Id);

            if (unVenta == null)
            {
                _listaVentas.Add(pVenta);
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Bajavent(short pId)
        {
            Venta unVenta = this.BuscarVenta(pId);
            if (unVenta != null)
            {
                _listaVentas.Remove(unVenta);

                return true;
            }
            else
                return false;
        }
        #endregion

        #region ABM Libro 
        public Libro BuscarLibro(short pId)
        {
            foreach (Libro unLibro in _listaLibros)
            {
                if (unLibro.Id == pId)
                {
                    return unLibro;

                }
            }
            return null;

        }

        public bool AltaLibro(Libro pLibro)
        {
            Libro unlibro = BuscarLibro(pLibro.Id);
            if (unlibro == null)
            {
                _listaLibros.Add(pLibro);
                
                return true;
            }
            else
                return false;


        }
        public bool BajaLibro(short pId)
        {
            Libro unlibro = BuscarLibro(pId);
            if (unlibro != null)
            {
                _listaLibros.Remove(unlibro);
                return true;
            }
            else
                return false;
        }
      
        public bool ModificarLibro(Libro pLibro)
        {
            Libro unlibro = BuscarLibro(pLibro.Id);
            {
                if (unlibro != null)
                {
                    unlibro.Id = pLibro.Id;
                    unlibro.Titulo = pLibro.Titulo;
                    unlibro.Genero = pLibro.Genero;
                    unlibro.Ano = pLibro.Ano;
                    unlibro.Autor = pLibro.Autor;
                    unlibro.Precio = pLibro.Precio;
                    unlibro.Pais = pLibro.Pais;
                    unlibro.Comentario = pLibro.Comentario;
                    return true;

                }
                else
                    return false;

            }
        

        }
        public List<Libro> ListaOrdenadaLibro()
        {
            List<Libro> LibrosOrdenados = new List<Libro>(_listaLibros);
            Libro auxLibro;
            for (int i = 0; i < LibrosOrdenados.Count; i++)
            {
                for (int j = 0; j < LibrosOrdenados.Count - 1; j++)
                {
                    if (LibrosOrdenados[j].Titulo.ToUpper().CompareTo(LibrosOrdenados[j + 1].Titulo.ToUpper()) > 0)
                    {
                        auxLibro = LibrosOrdenados[j];
                        LibrosOrdenados[j] = LibrosOrdenados[j + 1];
                        LibrosOrdenados[j + 1] = auxLibro;
                    }
                }
            }
            return LibrosOrdenados;
        }

        #endregion

        #region ABM Lectores

        public Lector BuscarLector(int pId)
        {
            foreach (Lector unLector in _listaLectores)
            {
                if (unLector.Id == pId)
                    return unLector;
            }
            return null;
        }

        public bool AltaLector(Lector pLector)
        {
            if (this.BuscarLector(pLector.Id) == null)
            {
                if (_persistencia.AltaLector(pLector))
                {
                    _listaLectores.Add(pLector);
                    return true;
                }

            }
            return false;
        }


        public bool BajaLector(int pId)
        {
            Lector unLector = BuscarLector(pId);
            if (unLector != null)
            {
                if (_persistencia.BajaLector(pId))
                {
                    _listaLectores.Remove(unLector);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarLector(Lector pLector)
        {
            Lector unLector = BuscarLector(pLector.Id);

            if (unLector != null)
            {
                _persistencia.ModificarLector(pLector);
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region ABM Autor
        public Autor BuscarAutor(int pId)
        {
            foreach (Autor unAutor in _listaAutores)
            {
                if (unAutor.Id == pId)
                    return unAutor;

                
            }
            return null;

        }
        public bool AltaAutor(Autor pAutor)
        {
            if(this.BuscarAutor(pAutor.Id) == null)
            {
                if(_persistencia.AltaAutor(pAutor))
                {
                    _listaAutores.Add(pAutor);
                    return true;
                }

            }
            return false;
        }

        
        public bool BajaAutor(int pId)
        {
            Autor unAutor = BuscarAutor(pId);
            if (unAutor != null)
            {
                if (_persistencia.BajaAutor(pId))
                {
                    _listaAutores.Remove(unAutor);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarAutor(Autor pAutor)
        {
            Autor unAutor = BuscarAutor(pAutor.Id);

            if (unAutor != null)
            {
                _persistencia.ModificarAutor(pAutor);
                return true;
            }
            else
            {
                return false;
            }
        }
            #endregion

        #region ABM generos
            public Genero BuscarGenero(int pId)
        {
            foreach (Genero unGenero in _listaGeneros)
            {
                if (unGenero.Id == pId)
                    return unGenero;


            }
            return null;

        }
        public bool AltaGenero(Genero pGenero)
        {
            if (this.BuscarGenero(pGenero.Id) == null)
            {
                if (_persistencia.AltaGenero(pGenero))
                {
                    _listaGeneros.Add(pGenero);
                    return true;
                }

            }
            return false;
        }


        public bool BajaGenero(int pId)
        {
            Genero unGenero = BuscarGenero(pId);
            if (unGenero != null)
            {
                if (_persistencia.BajaGenero(pId))
                {
                    _listaGeneros.Remove(unGenero);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarGenero(Genero pGenero)
        {
            Genero unGenero = BuscarGenero(pGenero.Id);

            if (pGenero != null)
            {
                if (_persistencia.ModificarGenero(pGenero))
                    unGenero.Id = pGenero.Id;
                unGenero.Nombre = pGenero.Nombre;


                return true;

            }
            else
                return false;
        }
        #endregion

        #region ABM Paises
        public Pais BuscarPais(int pId)
        {
            foreach (Pais unPais in _listaPaises)
            {
                if (unPais.Id == pId)
                    return unPais;


            }
            return null;

        }
        public bool AltaPais(Pais pPais)
        {
            if (this.BuscarPais(pPais.Id) == null)
            {
                if (_persistencia.AltaPais(pPais))
                {
                    _listaPaises.Add(pPais);
                    return true;
                }

            }
            return false;
        }


        public bool BajaPais(int pId)
        {
            Pais unPais = BuscarPais(pId);
            if (unPais != null)
            {
                if (_persistencia.BajaPais(pId))
                {
                    _listaPaises.Remove(unPais);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarPais(Pais pPais)
        {
            Pais unPais = BuscarPais(pPais.Id);

            if (pPais != null)
            {
                if (_persistencia.ModificarPais(pPais))
                    unPais.Id = pPais.Id;
                unPais.Nombre = pPais.Nombre;


                return true;

            }
            else
                return false;
        }
        #endregion


        #region Consultas
        public double Recaudacion()
            {
            double resultado = 0;
                foreach (Venta unVenta in _listaVentas)
                {
                    
                     resultado  = resultado + unVenta.Libro.Precio;
                       

                }
                return resultado;
            }


      


        public bool IngresoCant()
        {
            foreach (Venta unaVenta in _listaVentas)
            {
                foreach (Autor unAutor in _listaAutores)
                {
                    if (unAutor.Id == unaVenta.Libro.Autor.Id)
                    {
                        unAutor.LibrosVend++;
                        
                    }


                }
            
            }
          return true;
        } 
        public List<Autor> AutorConMasLibrosVend()
        {
            int mayor = 0;
            List<Autor> AutorVentas = new List<Autor>(_listaAutores);
            foreach(Autor unAutor in _listaAutores)
            {
                if (unAutor.LibrosVend > 0 && unAutor.LibrosVend > mayor)
                {
                    AutorVentas.Clear();
                    AutorVentas.Add(unAutor);
                    mayor = unAutor.LibrosVend;
                }
                else if(unAutor.LibrosVend> 0 && unAutor.LibrosVend ==mayor)
                {
                    AutorVentas.Add(unAutor);
                    mayor = unAutor.LibrosVend;

                }
            }
            return AutorVentas;
            
        }

        public bool IngresoCantLib()
        {
            foreach (Venta unaVenta in _listaVentas)
            {
                foreach (Libro unLibro in _listaLibros)
                {
                    if (unLibro.Id == unaVenta.Libro.Id)
                    {
                        unLibro.CantVend++;
                        
                    }


                }

            }
            return true;
           
        }

        public List<Libro>LibroConMasVent()
        {
            int mayor = 0;
            List<Libro> LibroVentas = new List<Libro>(_listaLibros);
            foreach (Libro unLibro in _listaLibros)
            {
                if (unLibro.CantVend > 0 && unLibro.CantVend > mayor)
                {
                    LibroVentas.Clear();
                    LibroVentas.Add(unLibro);
                    mayor = unLibro.CantVend;
                }
                else if (unLibro.CantVend > 0 && unLibro.CantVend == mayor)
                {
                  LibroVentas.Add(unLibro);
                    mayor = unLibro.CantVend;

                }
            }
            return LibroVentas;

        }

        public List<Venta> LectorDadoNom(string pNombre)
        {
          
            Lector unLecNom = this.BuscarLectorNom(pNombre);
            List<Venta> LectVen = new List<Venta>();
            foreach (Venta unaVenta in _listaVentas)
            {
                if (unLecNom != null)
                {
                    if (unaVenta.Lector.Nombre == unLecNom.Nombre)
                    {
                        LectVen.Add(unaVenta);

                    }
                }
            }
            return LectVen;


        }
     
               public Lector BuscarLectorNom(string pNombre)
        {
            foreach (Lector lector in _listaLectores)
            {
                if (lector.Nombre == pNombre)
                {
                    return lector;
                }
            }
            return null;

        }

        public bool IngresoCantPais()
        {
            foreach (Libro unLibro in _listaLibros)
            {
                foreach (Pais unPais in _listaPaises)
                {
                    if (unPais.Id == unLibro.Pais.Id)
                    {
                        unPais.Cantvend++;

                    }


                }

            }
            return true;

        }
        public List<Pais> PaisConMasPub()
        {
            int mayor = 0;
            List<Pais> PaisVentas = new List<Pais>(_listaPaises);
            foreach (Pais unPais in _listaPaises)
            {
                if (unPais.Cantvend > 0 && unPais.Cantvend > mayor)
                {
                    PaisVentas.Clear();
                    PaisVentas.Add(unPais);
                    mayor = unPais.Cantvend;
                }
                else if (unPais.Cantvend > 0 && unPais.Cantvend == mayor)
                {
                    PaisVentas.Add(unPais);
                    mayor = unPais.Cantvend;

                }
            }
            return PaisVentas;

        }

        public List<Libro> LibroDadoXGenero(string pGenero)
        {

            Genero unGenero = this.BuscarGeneroNom(pGenero);
            List<Libro> LibroDadoGen = new List<Libro>();
           
            foreach (Libro unLibro in ListaOrdenadaLibro())
            {
                if (unGenero != null)
                {
                    if(unGenero.Nombre == unLibro.Genero.Nombre)
                    {


                        LibroDadoGen.Add(unLibro);

                        
                    }
                }
            }
            return LibroDadoGen;


        }
       
        public Genero BuscarGeneroNom(string pNombre)
        {
            foreach (Genero unGenero in _listaGeneros)
            {
                if (unGenero.Nombre == pNombre)
                {
                    return unGenero;
                }
            }
            return null;
        }
            #endregion


        }
}