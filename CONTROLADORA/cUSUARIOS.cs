using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CONTROLADORA
{
    public class cUsuarios
    {
        private static cUsuarios instancia;
        private MODELO.CONTEXTO oModelo;
        public static cUsuarios obtenerInstancia()
        { 
            if (instancia == null)
                instancia = new cUsuarios();

            return instancia;
        }
        private cUsuarios()
        {
            oModelo = MODELO.CONTEXTO.obtenerInstancia();
        }

        public List<MODELO.usuario> ObtenerUsuarios()
        {
            return oModelo.usuarios.ToList();
        }

        public void ALTA(MODELO.usuario oUSUARIO)
        {
            oModelo.usuarios.Add(oUSUARIO);
            oModelo.SaveChanges();
        }
        public void BAJA(MODELO.usuario oUSUARIO)
        {
            oModelo.usuarios.Remove(oUSUARIO);
            oModelo.SaveChanges();
        }
        public void MODIFICACION(MODELO.usuario oUSUARIO)
        {
            oModelo.usuarios.Attach(oUSUARIO);
            oModelo.Entry(oUSUARIO).State = System.Data.Entity.EntityState.Modified;
            oModelo.SaveChanges();
        }
        public List<MODELO.grupo> ObtenerGrupos()
        {
            return oModelo.grupos.ToList();
        }

        public MODELO.usuario ObtenerMail(string mail)
        {
            MODELO.usuario oUsuario = oModelo.usuarios.FirstOrDefault(u => u.usu_email == mail);

            if (oUsuario == null)
            {
                throw new Exception("El mail ingresado no se encuentra registrado en el sistema");
            }


            return oUsuario;
        }

        public string ClaveAleatoria()
        {
            char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            Random random = new Random();
            int longitud = 6;
            string ClaveAleat = String.Empty;
            for (int i = 0; i < longitud; i++)
            {
                int rm = random.Next(0, 2);
                if (rm == 0)
                {
                    ClaveAleat += random.Next(0, 10);
                }
                else
                {
                    ClaveAleat += ValueAfanumeric[random.Next(0, 59)];
                }
            }
            return ClaveAleat;
        }

       public bool EnviarEmail(string aquien, string usuario, string clave)
        {
           
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(aquien);
            msg.From = new System.Net.Mail.MailAddress("guidotazziolli@gmail.com", "Guido Tazzioli", System.Text.Encoding.UTF8);
            msg.Subject = "Recuperacion de Clave";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = ("La password de la cuenta " + usuario + " es " + clave);
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("guidotazziolli@gmail.com", "truecrume1");
            cliente.Port = 587;
            cliente.Host = "smtp.gmail.com";
            cliente.EnableSsl = true;
            try
            {
                cliente.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
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
