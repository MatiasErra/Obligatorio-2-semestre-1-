using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2asp.Dominio;

namespace Obligatorio2asp.Persistencia
{
    public class ControladorPersistencia
    {
        #region Persistencia Autores
        public bool ExisteAutor(Autor pAutor)
        {
            return new PAutor().Existe(pAutor);
        }
        public bool AltaAutor(Autor pAutor)
        {
            return new PAutor().Alta(pAutor);
        }

        public bool BajaAutor(int pId)
        {
            return new PAutor().Baja(pId);
        }

        public bool ModificarAutor(Autor pAutor)
        {
            return new PAutor().Modificar(pAutor);
        }
        /*
        public bool ActAutor(Autor pAutor)
        {
            return new PAutor().ActuVenta(pAutor);
        }
        */
        public List<Autor> ListaAutores()
        {
            return new PAutor().Lista();
        }
        #endregion

        #region Persistencia Lectores
        public bool ExisteLector(Lector pLector)
        {
            return new PLector().Existe(pLector);
        }
        public bool AltaLector(Lector pLector)
        {
            return new PLector().Alta(pLector);
        }

        public bool BajaLector(int pId)
        {
            return new PLector().Baja(pId);
        }

        public bool ModificarLector(Lector pLector)
        {
            return new PLector().Modificar(pLector);
        }

        public List<Lector> ListaLectores()
        {
            return new PLector().Lista();
        }
        #endregion

        #region Persistencia Genero

        public bool AltaGenero(Genero pGenero)
        {
            return new PGenero().Alta(pGenero);
        }
        public bool BajaGenero(int pId)
        {
            return new PGenero().Baja(pId);
        }

        public bool ModificarGenero(Genero pGenero)
        {
            return new PGenero().Modificar(pGenero);
        }
        public List<Genero> ListaGenero()
        {
            return new PGenero().Lista();
        }
        #endregion

        #region Persistencia Pais

        public bool AltaPais(Pais pPais)
        {
            return new PPais().Alta(pPais);
        }
        public bool BajaPais(int pId)
        {
            return new PPais().Baja(pId);
        }

        public bool ModificarPais(Pais pPais)
        {
            return new PPais().Modificar(pPais);
        }
        public List<Pais> ListaPaises()
        {
            return new PPais().Lista();
        }
        #endregion
    }
}