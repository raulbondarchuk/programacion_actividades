using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    internal class Paquete : Envio
    {
        // Precio/Gramo depende de tipo de envio
        const double PRECIO_NACIONAL_GRAMOS = 0.0015d; // 0,0015 €/g
        const double PRECIO_INTERNACIONAL_GRAMOS = 0.002d; // 0,002 €/g
        // Precio/cm3 depende de tipo de envio
        const double PRECIO_NACIONAL_VOLUMEN = 0.0015d; // 0,0002 €/cm3
        const double PRECIO_INTERNACIONAL_VOLUMEN = 0.002d; // 0,00042 €/cm3

        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int Profundo { get; set; }

        // Volumen = L × W × H. Alto "L", Ancho "W" y Profundo "Н"
        public int ObtenerVolumenDelPaquete()
        {
            return Alto * Ancho * Profundo;
        }
        public double ObtenerNumeroMayor(double a, double b)
        {
            if (a > b || a == b)
                return a;
            else
                return b;
        }
        public override double ObtenerPrecioEnvio()
        {
            double resultGramo = 0; // es el resultado con el calculo Precio/Gramo
            double resultVolumen = 0; // es el resultado con el calculo Precio/cm3

            if (TipoEnvio == TipoEnvio.Nacional)
            {
                resultGramo = PRECIO_NACIONAL_GRAMOS * PesoGramos;
                resultVolumen = PRECIO_NACIONAL_VOLUMEN * ObtenerVolumenDelPaquete();
            }
            else if (TipoEnvio == TipoEnvio.Internacional)
            {
                resultGramo = PRECIO_INTERNACIONAL_GRAMOS * PesoGramos;
                resultVolumen = PRECIO_INTERNACIONAL_VOLUMEN * ObtenerVolumenDelPaquete();
            }

            return ObtenerNumeroMayor(resultGramo, resultVolumen);
        }
    }
}
