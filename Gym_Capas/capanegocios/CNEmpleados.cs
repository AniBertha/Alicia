using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDeDatos;
using MySql.Data.MySqlClient;

namespace capaNegocios
{
    public class CNEmpleados
    {
        //Encapsulamiento de variables
        private CDEmpleados objDato = new CDEmpleados();
        //Variables
        private String _Nombre;
        private String _Apellidos;
        private String _Edad;
        private String _Domicilio;
        private String _Telefono;
        private String _Usuario;
        private String _Contrasenia;
        private String _Tipo_de_usuario;
        private String _Notas;
        private String _Correo_elec;


        public String Nombre
        {
            set{ _Nombre = value; }
            get{ return _Nombre; }
        }

        public String Apellidos
        {
            set { _Apellidos = value; }
            get { return _Apellidos; }
        }

        public String Edad
        {
            set { _Edad = value; }
            get { return _Edad; }
        }

        public String Domicilio
        {
            set { _Domicilio = value; }
            get { return _Domicilio; }
        }

        public String Telefono
        {
            set { _Telefono = value; }
            get { return _Telefono; }
        }

        public String Usuario
        {
            set
            {
                if (value == "USUARIO")
                {
                    _Usuario = "No ha ingresado Usuario!";
                }
                else { _Usuario = value; }
            }
            get { return _Usuario; }
        }

        public String Contrasenia
        {
            set
            {
                if (value == "CONTRASEÑA")
                {
                    _Contrasenia = "No ha ingresado Contraseña!";
                }
                else { _Contrasenia = value; }
            }
            get { return _Contrasenia; }
        }

        public String Correo_elec
        {
            set
            {
                if(value=="CORREO")
                {
                    _Correo_elec = "No ha ingresado su Correo";
                }
                else { _Correo_elec = value; }
            }
            get { return _Correo_elec; }
        }

        public String Tipo_de_usuario
        {
            set { _Tipo_de_usuario = value; }
            get { return _Tipo_de_usuario; }
        }

        public String Notas
        {
            set { _Notas = value; }
            get { return _Notas; }
        }

        

        //Constructor
        public CNEmpleados(){}
        //Funciones o metodos
        public MySqlDataReader iniciarSesion()
        {
            MySqlDataReader loguear;
            loguear = objDato.iniciarSesion(Usuario, Contrasenia);

            return loguear;
        }

        public MySqlDataReader enviar_Correo()
        {
            MySqlDataReader loguear;
            loguear = objDato.enviar_Correo(Correo_elec);
            return loguear;
        }



    }
}
