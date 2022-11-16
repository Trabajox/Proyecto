using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ahorasi.Models;
using System.Data.SqlClient;
using System.Data;

namespace Ahorasi.Logica
{
    public class LO_Usuario
    {
        public Usuarios EncontrarUsuario(string correo,string clave)
        {
            Usuarios objeto = new Usuarios();

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-E7AGSG4\\SQLEXPRESS; Initial Catalog=autenticacion; Integrated Security=true"))
            {
                string query = "select Nombres,Correo,Clave,IdRol from Usuarios where Correo=@pcorreo and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;

                conexion.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new Usuarios()
                        {
                            Nombres = dr["Nombres"].ToString(), 
                            Correo = dr["Correo"].ToString(), 
                            Clave = dr["Clave"].ToString(), 
                            IdRol = (Rol)dr["IdRol"]
                        };

                    }

                }
            }


                return objeto;
        }

         
    }
}