using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2asp.Dominio
{
    public class Pais
    {
        private int _id;
        private string _nombre;
        private int _cantvend;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Cantvend { get => _cantvend; set => _cantvend = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Nombre;
        }
        public Pais(int pId, string pNombre)
        {
            this.Id = pId;
            this.Nombre = pNombre;
        }
    }
}