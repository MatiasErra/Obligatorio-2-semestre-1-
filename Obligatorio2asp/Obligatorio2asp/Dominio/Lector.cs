using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio2asp.Dominio
{
    public class Lector:Persona
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public Lector(int pId, string pNombre, string pApellido)
            :base(pId, pNombre, pApellido)
        { }
    }
}
