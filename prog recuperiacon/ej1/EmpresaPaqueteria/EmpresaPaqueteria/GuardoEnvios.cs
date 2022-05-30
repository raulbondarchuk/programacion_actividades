using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    internal class GuardoEnvios
    {
        public List<Envio> Envios { get; set; } = new List<Envio>();

        public List<Envio> ObtenerListaEnviosRetrasados()
        {
            List<Envio> EnviosRetrasados = new List<Envio>();
            for (int i = 0; i < Envios.Count; i++)
            {
                if(Envios[i].FechaHoraPrevista < Envios[i].EstadoEnvio.FechaHoraEntrega)
                {
                    EnviosRetrasados.Add(Envios[i]);
                }
            }
            return EnviosRetrasados;
        }
    }
}
