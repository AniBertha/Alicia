using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
using System.Data;

namespace capaDeDatos
{
    class CDConexion
    {
        private MySqlConnection conexion= new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=gym_silver;User Id=administrador;password='';");

        public MySqlConnection abrirConexion()
        {
            if(conexion.State==ConnectionState.Closed)   
                conexion.Open();
                return conexion;            
        }

        public MySqlConnection cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
                return conexion;
        }
    }
}
