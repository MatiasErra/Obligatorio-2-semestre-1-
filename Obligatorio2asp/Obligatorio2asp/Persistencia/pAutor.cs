using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2asp.Dominio;
using System.Data;

namespace Obligatorio2asp.Persistencia
{
    public class PAutor
    {
        
        private Conexión conexión = new Conexión();

        public bool Existe(Autor pAutor)
        {
            if (pAutor == null) { return false; }

            string sql = "SELECT * FROM Autores WHERE id =" + pAutor.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pAutor
        }


        public List<Autor> Lista()
            {
                string sql = "Select * From Autores";
                DataSet datos = conexión.Selección(sql);
                List<Autor> lista = new List<Autor>();
                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    Autor unAlumno = new Autor(
                        short.Parse(fila[0].ToString()),
                        fila[1].ToString(),
                        fila[2].ToString(),
                        fila[3].ToString(),
                       fila[4].ToString(),
                        fila[5].ToString()
                     
                        );
                    lista.Add(unAlumno);
                }
                return lista;
        }

        public bool Alta(Autor pAutor)
        {
            string sql = "INSERT INTO Autores (id,nombre,apellido,nacionalidad,fechaden,fechadef) VALUES("
                + pAutor.Id.ToString() + ","
                + "'" + pAutor.Nombre + "',"
                + "'" + pAutor.Apellido + "',"
                + "'" + pAutor.Nacionalidad + "',"
                + "'" + pAutor.FechaDeN + "',"
                + "'" + pAutor.FechaDeF + "');";
            return this.conexión.Consulta(sql);
        }

        public bool Baja(int pId)
            {
                string sql = "DELETE FROM Autores WHERE id=" + pId.ToString();
                return this.conexión.Consulta(sql);
            }

            public bool Modificar(Autor pAutor)
            {
                string sql = "UPDATE Autores SET "
                    + "nombre='" + pAutor.Nombre + "',"
                    + "apellido='" + pAutor.Apellido + "',"
                    + "nacionalidad='" + pAutor.Nacionalidad + "',"
                    + "fechaden='" + pAutor.FechaDeN + "',"
                    + "fechadef='" + pAutor.FechaDeF + "' "
                    + "WHERE id=" + pAutor.Id.ToString();
                return this.conexión.Consulta(sql);
            }
      
        }
    }
