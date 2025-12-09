using System;
using System.Windows.Forms;

namespace examen
{
    public class Jugando : IEstadoSala
    {
        public void AgregarJugador(Formsala sala, Jugador jugador)
        {
            MessageBox.Show("La sala ya tiene 2 jugadores.", "Info");
        }

        public void JugadorElige(Formsala sala, int jugador, string eleccion)
        {
            sala.GuardarEleccion(jugador, eleccion);

            if (sala.EleccionesCompletas())
            {
                sala.DeterminarGanador();
            }
        }


        public void EntrarEstado(Formsala sala)
        {
            sala.ActualizarEstadoLabel("¡La partida empezó!");
            sala.MostrarBotones();
        }
    }
}
