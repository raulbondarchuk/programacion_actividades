using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    public enum TipoEnvio
    {
        Nacional,
        Internacional
    }
    internal abstract class Envio
    {
        public string numSeguimiento { get; set; }
        public Cliente Retimente { get; set; }
        public Cliente Destinatario { get; set; }
        public TipoEnvio TipoEnvio { get; set; } = TipoEnvio.Nacional; // default
        public DateTime FechaHoraPrevista { get; set; }
        public int PesoGramos { get; set; }

        public EstadoEnvio EstadoEnvio { get; set; } = new EstadoEnvio(); // estado paquete

        public abstract double ObtenerPrecioEnvio();
    }
}
