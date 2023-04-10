using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CONTROLADORA
{
    public class cLogin
    {
        private static cLogin instancia;
        private MODELO.CONTEXTO oModelo;
        public static cLogin obtenerInstancia()
        { 
            if (instancia == null)
                instancia = new cLogin();

            return instancia;
        }
        private cLogin()
        {
            oModelo = MODELO.CONTEXTO.obtenerInstancia();
        }

        public MODELO.usuario LOGIN(string usuario, string password)
        {
            MODELO.usuario oUsuario = oModelo.usuarios.FirstOrDefault(u => u.usu_codigo == usuario);

            if (oUsuario == null)
            {
                throw new Exception("El usuario ingresado no se encuentra registrado en el sistema");               
            }

            if (oUsuario.usu_clave != password)
            {
                throw new Exception("La contraseña ingresada es incorrecta");
            }

            if (oUsuario.usu_estado == false)
            {
                throw new Exception("El usuario ingresado se encuentra inactivo");
            }


            return oUsuario;
        }


        public string EncriptarClave(string clave)
        {
            byte[] passBytes = Encoding.Unicode.GetBytes(clave);
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(passBytes);
            string hashString = Encoding.Unicode.GetString(hash);
            return hashString;
        }
    }
}
