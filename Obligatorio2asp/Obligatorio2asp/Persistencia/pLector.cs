using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2asp.Dominio;
using System.Data;

namespace Obligatorio2asp.Persistencia
{
    public class PLector
    {
        private Conexión conexión = new Conexión();

        public bool Existe(Lector pLector)
        {
            if (pLector == null) { return false; }

            string sql = "SELECT * FROM Lectores WHERE id =" + pLector.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pAutor
        }


        public List<Lector> Lista()
        {
            string sql = "Select * From Lectores";
            DataSet datos = conexión.Selección(sql);
            List<Lector> lista = new List<Lector>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Lector unLector = new Lector(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString()
                    );
                lista.Add(unLector);
            }
            return lista;
        }

        public bool Alta(Lector pLector)
        {
            string sql = "INSERT INTO Lectores (id,nombre,apellido) VALUES("
                + pLector.Id.ToString() + ","
                + "'" + pLector.Nombre + "',"
                + "'" + pLector.Apellido + "');";
            return this.conexión.Consulta(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Lectores WHERE id=" + pId.ToString();
            return this.conexión.Consulta(sql);
        }

        public bool Modificar(Lector pLector)
        {
            string sql = "UPDATE Lectores SET "
                + "nombre='" + pLector.Nombre + "',"
                + "apellido='" + pLector.Apellido + "' "
                + "WHERE id=" + pLector.Id.ToString();
            return this.conexión.Consulta(sql);
        }
    }
}
