using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio2asp.Dominio
{
    public class Autor:Persona
    {
        private string _fechaDeN;
        private string _fechaDeF;
        private string _nacionalidad;
        private int _librosVend;

        public string FechaDeN { get => _fechaDeN; set => _fechaDeN = value; }
        public string FechaDeF { get => _fechaDeF; set => _fechaDeF = value; }
        public string Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        public int LibrosVend { get => _librosVend; set => _librosVend = value; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Nacionalidad + " " + this.FechaDeN + " " + this.FechaDeF;


        }
     
        public Autor(int pId, string pNombre, string pApellido, string pNacionalidad, string pFechaDeN, string pFechaDeF)
            : base(pId, pNombre, pApellido)
        {
            this.FechaDeN = pFechaDeN;
            this.FechaDeF = pFechaDeF;
            this.Nacionalidad = pNacionalidad;
         
        }
    }
}
