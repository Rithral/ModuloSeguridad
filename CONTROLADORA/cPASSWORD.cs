using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CONTROLADORA
{
    public class cPassword
    {
        private static cPassword instancia;
        private MODELO.CONTEXTO oModelo;
        public static cPassword obtenerInstancia()
        { 
            if (instancia == null)
                instancia = new cPassword();

            return instancia;
        }
        private cPassword()
        {
            oModelo = MODELO.CONTEXTO.obtenerInstancia();
        }

        public void MODIFICACION(MODELO.usuario oUSUARIO)
        {
            oModelo.Entry(oUSUARIO).State = System.Data.Entity.EntityState.Modified;
            oModelo.SaveChanges();
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
