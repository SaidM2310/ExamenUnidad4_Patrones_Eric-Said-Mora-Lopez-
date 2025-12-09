using System;
using System.Windows.Forms;

namespace examen
{
    public class Finalizada : IEstadoSala
    {
        public void AgregarJugador(Formsala sala, Jugador jugador)
        {
            MessageBox.Show("La partida ya finalizó.", "Info");
        }

        public void JugadorElige(Formsala sala, int jugador, string eleccion)
        {
            MessageBox.Show("La partida ya finalizó.", "Info");
        }

        public void EntrarEstado(Formsala sala)
        {
            sala.ActualizarEstadoLabel("Partida finalizada");
        }
    }
}
