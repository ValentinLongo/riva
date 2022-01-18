using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rivadavia.BLL
{
    class JugadoresBLL
    {
        public int ID { get; set; }
        public string NombreJugador { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int DNI { get; set; }
        public int Telefono1 { get; set; }
        public int Telefono2 { get; set; }
        public string Correo { get; set; }
        public int FechaInicio { get; set; }
        public int FechaSalida{ get; set; }

        public byte[] FotoJugador { get; set; }
        
    }
}
