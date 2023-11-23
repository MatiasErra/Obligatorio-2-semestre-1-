using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio2asp.Dominio
{
    public class Libro
    {
        private short _id;
        private string _titulo;
        private Genero _genero;
        private string _ano;
        private Autor _autor;
        private Pais pais;
        private double _precio;
        private string _comentario;
        private int _cantVend;

        public short Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public Genero Genero { get => _genero; set => _genero = value; }
        public string Ano { get => _ano; set => _ano = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public string Comentario { get => _comentario; set => _comentario = value; }
        internal Autor Autor { get => _autor; set => _autor = value; }
        public int CantVend { get => _cantVend; set => _cantVend = value; }
        public Pais Pais { get => pais; set => pais = value; }

        public override string ToString()
        {
            return this.Id +" " + this.Titulo + " " +  this.Autor.Nombre + " "+ this.Genero.Nombre + " " + this.Pais.Nombre + " "+ this.Ano + " $" + this.Precio + " " + this.CantVend;
        }




        public Libro(short pId, string pTitulo,string pAno, Genero pGenero,  Autor pAutor, Pais pPais, double pPrecio, string pComentario)
        {
            this.Id = pId;
            this.Titulo = pTitulo;
            this.Genero = pGenero;
            this.Ano = pAno;
            this.Autor = pAutor;
            this.Pais = pPais;
            this.Precio = pPrecio;
            this.Comentario = pComentario;

        }
    }
}
