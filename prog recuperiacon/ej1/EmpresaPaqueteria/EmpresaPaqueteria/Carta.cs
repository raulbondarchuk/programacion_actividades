using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    internal class Carta : Envio
    {
        // Precio/Gramo depende de tipo de envio
        const double PRECIO_NACIONAL = 0.014d; // 0,014 €/g
        const double PRECIO_INTERNACIONAL = 0.022d; // 0,022 €/g

        public bool Certificada { get; set; }

       
        public override double ObtenerPrecioEnvio()
        {
            double result = 0;

            if (TipoEnvio == TipoEnvio.Nacional)
            {
                if (Certificada)
                    result = (PRECIO_NACIONAL * PesoGramos) * 2;
                else
                    result = (PRECIO_NACIONAL * PesoGramos);
            }
            else if (TipoEnvio == TipoEnvio.Internacional)
            {
                if (Certificada)
                    result = (PRECIO_INTERNACIONAL * PesoGramos) * 2;
                else
                    result = (PRECIO_INTERNACIONAL * PesoGramos);
            }
                
            return result;
        }
    }
}
