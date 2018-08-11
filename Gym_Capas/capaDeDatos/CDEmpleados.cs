using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;


namespace capaDeDatos
{
    public class CDEmpleados
    {
        private CDConexion Conexion = new CDConexion();
        private MySqlDataReader leer;

        public MySqlDataReader iniciarSesion(string user, string pass)
        {
            MySqlCommand comando = new MySqlCommand("SP_IniciarSesion",Conexion.abrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_usuario",user);
            comando.Parameters.AddWithValue("_contrasenia", pass);
            leer = comando.ExecuteReader();
            return leer;
        }

        public MySqlDataReader enviar_Correo(string correo)
        {
            MySqlCommand comandoCorreo = new MySqlCommand("SP_RecuperarContra",Conexion.abrirConexion());
            comandoCorreo.CommandType = CommandType.StoredProcedure;
            comandoCorreo.Parameters.AddWithValue("_correo",correo);
            leer = comandoCorreo.ExecuteReader();

            return leer;
        }

       
    }
}
