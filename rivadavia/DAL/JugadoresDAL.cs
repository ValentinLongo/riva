using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using rivadavia.BLL;

namespace rivadavia.DAL
{
    class JugadoresDAL
    {
        conexionDAL conexion;

        public JugadoresDAL()
        {
            conexion = new conexionDAL();
        }

        public bool Agregar(JugadoresBLL oJugadoresBLL)
        {
           return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Jugadores (nombres, primerapellido, segundoapellido, dni, teluno, teldos, correo, fechainicio, fechasalida) VALUES('"+ oJugadoresBLL.NombreJugador+ "','" + oJugadoresBLL.PrimerApellido+ "','" + oJugadoresBLL.SegundoApellido+ "','"+ oJugadoresBLL.DNI + "','" + oJugadoresBLL.Telefono1 + "','" + oJugadoresBLL.Telefono2 + "','" + oJugadoresBLL.Correo + "','" + oJugadoresBLL.FechaInicio + "','" + oJugadoresBLL.FechaSalida + "') ");
        }

        public bool Eliminar(JugadoresBLL oJugadoresBLL)
        {
           conexion.ejecutarComandoSinRetornoDatos("DELETE FROM Jugadores WHERE ID=" + oJugadoresBLL.ID);
           return true;
        }

        public bool Modificar(JugadoresBLL oJugadoresBLL)
        {
            conexion.ejecutarComandoSinRetornoDatos("UPDATE Jugadores " +
                "SET nombres='"+oJugadoresBLL.NombreJugador+ "', primerapellido='" + oJugadoresBLL.PrimerApellido + "', segundoapellido='" + oJugadoresBLL.SegundoApellido + "', dni='" + oJugadoresBLL.DNI + "', teluno='" + oJugadoresBLL.Telefono1 + "', teldos='" + oJugadoresBLL.Telefono2 + "', correo='" + oJugadoresBLL.Correo + "', fechainicio='" + oJugadoresBLL.FechaInicio + "', fechasalida='" + oJugadoresBLL.FechaSalida + "' " + 
                " WHERE ID=" + oJugadoresBLL.ID);
            return true;
        }

        public DataSet MostrarJugadores()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Jugadores");
            return conexion.EjecutarSentencia(sentencia);
        }

    }
}
