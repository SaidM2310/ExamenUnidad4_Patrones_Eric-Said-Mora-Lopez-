using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace examen
{
    public class ControladorJuego
    {
        private FachadaJuego fachada;

        public ControladorJuego()
        {
            fachada = new FachadaJuego();
        }

        public Jugador ConectarJugador(Form formulario)
        {
            Jugador jugador = fachada.ConectarJugador();
            if (jugador != null)
            {
                formulario.Controls.Add(jugador.Cuerpo);
                jugador.Cuerpo.BringToFront();
            }
            return jugador;
        }

        public void DesconectarJugador(Form formulario, Jugador jugador)
        {
            fachada.DesconectarJugador(formulario, jugador);
        }

        public Formsala CrearSala(Jugador jugador)
        {
            return fachada.CrearSala(jugador);
        }

        public void CerrarSala(Formsala sala)
        {
            fachada.CerrarSala(sala);
        }

        public List<Jugador> ObtenerJugadoresActivos()
        {
            return fachada.ObtenerJugadoresActivos();
        }
    }
}
