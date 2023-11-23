using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2asp.Dominio;
using System.Data;

namespace Obligatorio2asp.Persistencia
{
    public class PGenero
    {
        private Conexión conexión = new Conexión();

        public bool Existe(Genero pGenero)
        {
            if (pGenero == null) { return false; }

            string sql = "SELECT * FROM Generos WHERE id =" + pGenero.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pGenero
        }

        public List<Genero> Lista()
        {
            string sql = "Select * From Generos";
            DataSet datos = conexión.Selección(sql);
            List<Genero> lista = new List<Genero>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Genero unGenero = new Genero(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString()
                    );
                lista.Add(unGenero);
            }
            return lista;
        }

        public bool Alta(Genero pGenero)
        {
            string sql = "INSERT INTO Generos (id,nombre) VALUES("
                + pGenero.Id.ToString() + ","
                + "'" + pGenero.Nombre+
                "')";
            return this.conexión.Consulta(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Generos WHERE id=" + pId.ToString();
            return this.conexión.Consulta(sql);
        }
        public bool Modificar(Genero pGenero)
        {
            string sql = "UPDATE Generos SET "
                + "nombre='" + pGenero.Nombre + "'" 
                + "WHERE id=" + pGenero.Id.ToString();
            return this.conexión.Consulta(sql);
        }
    }
}