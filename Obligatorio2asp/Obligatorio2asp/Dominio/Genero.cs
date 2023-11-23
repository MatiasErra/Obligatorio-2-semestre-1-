using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2asp.Dominio
{
    public class Genero
    {
        private int _id;
        private string _nombre;
        

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Nombre;
        }
        public Genero(int pId, string pNombre)
        {
            this.Id = pId;
            this.Nombre = pNombre;
        }
    }
}