using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio2asp.Dominio;
using System.Data;

namespace Obligatorio2asp.Persistencia
{
    public class PPais
    {
        
        private Conexión conexión = new Conexión();

        public bool Existe(Pais pPais)
        {
            if (pPais == null) { return false; }

            string sql = "SELECT * FROM Pais WHERE id =" + pPais.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  
        }

        public List<Pais> Lista()
        {
            string sql = "Select * From Pais";
            DataSet datos = conexión.Selección(sql);
            List<Pais> lista = new List<Pais>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Pais unPais = new Pais(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString()
                    );
                lista.Add(unPais);
            }
            return lista;
        }

        public bool Alta(Pais pPais)
        {
            string sql = "INSERT INTO Pais (id,nombre) VALUES("
                + pPais.Id.ToString() + ","
                + "'" + pPais.Nombre +
                "')";
            return this.conexión.Consulta(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Pais WHERE id=" + pId.ToString();
            return this.conexión.Consulta(sql);
        }
        public bool Modificar(Pais pPais)
        {
            string sql = "UPDATE Pais SET "
                + "nombre='" + pPais.Nombre + "'"
                + "WHERE id=" + pPais.Id.ToString();
            return this.conexión.Consulta(sql);
        }
    }
}
