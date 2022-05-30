using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaPaqueteria
{

    // duda sobre el volumen del maletero en Furgoneta y volumen del Envio (tiene peso, pero el volumen las cartas no tienen)
    internal class Program
    {
        static void Main(string[] args)
        {
            // PARTE A COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Cliente cOrigen = new Cliente();
            Cliente cDestino = new Cliente();

            Envio p1 = new Paquete();
            p1.PesoGramos = 6000;
            p1.numSeguimiento = "paq1";
            p1.FechaHoraPrevista = new DateTime(2021, 5, 28);

            Envio p2 = new Paquete();
            p2.PesoGramos = 2000;
            p2.TipoEnvio = TipoEnvio.Internacional;
            p2.numSeguimiento = "paq2";
            p2.FechaHoraPrevista = new DateTime(2023, 5, 28);

            Envio c1 = new Carta();
            c1.PesoGramos = 3000;
            c1.numSeguimiento = "car1";
            c1.FechaHoraPrevista = new DateTime(2024, 5, 28);

            Envio c2 = new Carta();
            c2.PesoGramos = 1000;
            c2.TipoEnvio = TipoEnvio.Internacional;
            c2.numSeguimiento = "car2";
            c2.FechaHoraPrevista = new DateTime(2021, 5, 28);

            Carta c3 = new Carta();
            c3.PesoGramos = 1000;
            c3.Certificada = true;
            c3.numSeguimiento = "car3";
            c3.FechaHoraPrevista = new DateTime(2022, 6, 1);

            Carta c4 = new Carta();
            c4.PesoGramos = 1000;
            c4.TipoEnvio = TipoEnvio.Internacional;
            c4.Certificada = true;
            c4.numSeguimiento = "car4";
            c4.FechaHoraPrevista = new DateTime(2022, 5, 30);
             
            Console.WriteLine("- - - PARTE A COMPROBACION - - -"); Console.WriteLine("* * * * * * * * * * * * * * * * * * *");

            Console.WriteLine("Paquete Nacional: " + p1.ObtenerPrecioEnvio());
            Console.WriteLine("Paquete Internacional: " + p2.ObtenerPrecioEnvio());
            Console.WriteLine("Carta Nacional: " + c1.ObtenerPrecioEnvio());
            Console.WriteLine("Carta Internacional: " + c2.ObtenerPrecioEnvio());
            Console.WriteLine("Carta Nacional Certificada: " + c3.ObtenerPrecioEnvio());
            Console.WriteLine("Carta Internacional Certificada: " + c4.ObtenerPrecioEnvio());
            Console.WriteLine("______________________________________________________"); Console.WriteLine(" ");
            // PARTE A COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            // PARTE B + C COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            Console.WriteLine("- - PARTE B y C COMPROBACION - -"); Console.WriteLine("* * * * * * * * * * * * * * * * * * *");

            // Mostrar estado envio
            Console.WriteLine("Estados paquetes * *"); Console.WriteLine("");
            Console.WriteLine(p1.numSeguimiento + " " + p1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(p2.numSeguimiento + " " + p2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c1.numSeguimiento + " " + c1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c2.numSeguimiento + " " + c2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c3.numSeguimiento + " " + c3.EstadoEnvio.Estado.ToString());
            Console.WriteLine("");

            Furgoneta f1 = new Furgoneta();
            f1.VolumenMaleteroKgs = 10; // en kgs
            // Carga envios a la furgoneta
            f1.CargaDescargaEnvios(p1, TipoCargaDescarga.Carga);
            f1.CargaDescargaEnvios(p2, TipoCargaDescarga.Carga);
            f1.CargaDescargaEnvios(c1, TipoCargaDescarga.Carga);
            f1.CargaDescargaEnvios(c2, TipoCargaDescarga.Carga);
            f1.CargaDescargaEnvios(c3, TipoCargaDescarga.Carga);

            // Comprobar contenido de la furgoneta
            Console.WriteLine("Cargo Furgoneta * *"); Console.WriteLine("");
            foreach (Envio envio in f1.Envios)
            {
                Console.WriteLine(envio + " " + envio.numSeguimiento);
            }
            Console.WriteLine("");
            // Mostrar estado envio 
            Console.WriteLine("Estados paquetes * *"); Console.WriteLine("");
            Console.WriteLine(p1.numSeguimiento + " " + p1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(p2.numSeguimiento + " " + p2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c1.numSeguimiento + " " + c1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c2.numSeguimiento + " " + c2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c3.numSeguimiento + " " + c3.EstadoEnvio.Estado.ToString());
            Console.WriteLine("");

            f1.CargaDescargaEnvios(p1, TipoCargaDescarga.Descarga);
            f1.CargaDescargaEnvios(c2, TipoCargaDescarga.Descarga);
            f1.CargaDescargaEnvios(c3, TipoCargaDescarga.Descarga);


            f1.CargaDescargaEnvios(c1, TipoCargaDescarga.Carga);

            Console.WriteLine("Cargo Furgoneta * *"); Console.WriteLine("");
            foreach (Envio envio in f1.Envios)
            {
                Console.WriteLine(envio + " " + envio.numSeguimiento);
            }
            Console.WriteLine("");

            Console.WriteLine("Estados paquetes * *"); Console.WriteLine("");
            Console.WriteLine(p1.numSeguimiento + " " + p1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(p2.numSeguimiento + " " + p2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c1.numSeguimiento + " " + c1.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c2.numSeguimiento + " " + c2.EstadoEnvio.Estado.ToString());
            Console.WriteLine(c3.numSeguimiento + " " + c3.EstadoEnvio.Estado.ToString());
            Console.WriteLine("");
            // PARTE B + C COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            Console.WriteLine("______________________________________________________"); Console.WriteLine(" ");
            // PARTE D COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            Console.WriteLine("- - - PARTE D COMPROBACION - - -"); Console.WriteLine("* * * * * * * * * * * * * * * * * * *");
            GuardoEnvios gEnvios = new GuardoEnvios();
            // Guardar los envios en nuestro gestor
            gEnvios.Envios.Add(p1);
            gEnvios.Envios.Add(p2);
            gEnvios.Envios.Add(c1);
            gEnvios.Envios.Add(c2);
            gEnvios.Envios.Add(c3);
            gEnvios.Envios.Add(c4);

            List<Envio> enviosRetrasados = gEnvios.ObtenerListaEnviosRetrasados();

            Console.WriteLine("Los envios entregados con retraso * *");
            foreach(Envio envio in enviosRetrasados)
            {
                Console.WriteLine(envio + " | Nombre: " + envio.numSeguimiento + " | Fecha Prevista: " 
                    + envio.FechaHoraPrevista + " | Fecha Entrega: " + envio.EstadoEnvio.FechaHoraEntrega);
            }

            // PARTE D COMPROBACION - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            Console.ReadKey();
        }
    }
}
