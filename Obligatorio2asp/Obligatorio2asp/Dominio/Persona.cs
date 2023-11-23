using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio2asp.Dominio
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellido;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Nombre + " " + this.Apellido;
        }

        public Persona(int pId, string pNombre, string pApellido)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
        }
    }
}
