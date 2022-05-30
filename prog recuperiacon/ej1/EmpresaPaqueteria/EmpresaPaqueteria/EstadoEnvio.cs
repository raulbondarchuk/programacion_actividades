using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    public enum TipoDeEstadoEnvio
    {
        CentroLogistico,
        Transito,
        Entregado
    }

    internal class EstadoEnvio
    {
        private TipoDeEstadoEnvio estado;
        public TipoDeEstadoEnvio Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                if (value == TipoDeEstadoEnvio.Entregado)
                {
                    FechaHoraEntrega = DateTime.Now;
                }
            }
        }
        public DateTime FechaHoraEntrega { get; set; }
    }
}
