using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    public class Esperando : IEstadoSala
    {
        public void AgregarJugador(Formsala sala, Jugador jugador)
        {
            sala.Jugadores.Add(jugador);
            if (sala.Jugadores.Count == 2)
            {
                sala.CambiarEstado(new Jugando());
            }
            else
            {
                sala.ActualizarEstadoLabel("Falta 1 jugador para empezar...");
            }
        }

        public void JugadorElige(Formsala sala, int jugador, string eleccion)
        {
            MessageBox.Show("Esperando más jugadores...", "Info");
        }

        public void EntrarEstado(Formsala sala)
        {
            sala.ActualizarEstadoLabel("Esperando jugadores...");
        }
    }

}
