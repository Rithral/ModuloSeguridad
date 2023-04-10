using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public partial class CONTEXTO
    {
        private static CONTEXTO instancia;

        public static CONTEXTO obtenerInstancia()
        {
            if (instancia == null)
                instancia = new CONTEXTO();

            return instancia;
        }

    }
}
