using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{
    public enum TipoCargaDescarga
    {
        Carga,
        Descarga
    }
    internal class Furgoneta
    {
        public string Matricula { get; set; }
        public int VolumenMaleteroKgs { get; set; } // en kg
        public List<Envio> Envios { get; set; } = new List<Envio>();

        public void CargaDescargaEnvios(Envio envio, TipoCargaDescarga tipo) 
        {
            // si hacemos carga
            if (tipo == TipoCargaDescarga.Carga)
            {
                if (((CargaTotalDelMaletero() + envio.PesoGramos) / 1000) <= VolumenMaleteroKgs) // dividimos a 1000 porque gramos --> kgs
                {
                    envio.EstadoEnvio.Estado = TipoDeEstadoEnvio.Transito;
                    Envios.Add(envio);
                }
                    
            }
            // si hacemos descarga
            else if (tipo == TipoCargaDescarga.Descarga)
            {
                if (EncontrarPosicionEnvio(envio) != -1)
                {
                    envio.EstadoEnvio.Estado = TipoDeEstadoEnvio.Entregado;
                    Envios.RemoveAt(EncontrarPosicionEnvio(envio));
                }
            }
        }
        // si volumen envios es mayor que volumen maletero --> se devuelve false
        public double CargaTotalDelMaletero() 
        {
            double contadorPeso = 0;
            for(int i = 0; i < Envios.Count; i++)
            {
                contadorPeso += Envios[i].PesoGramos;
            }
            return (contadorPeso);
        }
        public int EncontrarPosicionEnvio(Envio envio)
        {
            int result = -1;

            for (int i = 0; i < Envios.Count; i++)
            {
                if(envio == Envios[i])
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
