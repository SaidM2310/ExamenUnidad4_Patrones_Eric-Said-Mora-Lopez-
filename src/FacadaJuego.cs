using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace examen
{
    public class FachadaJuego
    {
        private PoolJugadores pool;
        private ServidorPartida servidor;

        public FachadaJuego()
        {
            pool = new PoolJugadores();
            servidor = ServidorPartida.Instancia;
        }

        public Jugador ConectarJugador()
        {
            return pool.ObtenerJugador();
        }

        public void DesconectarJugador(Form formulario, Jugador jugador)
        {
            if (jugador == null) return;
            formulario.Controls.Remove(jugador.Cuerpo);
            pool.LiberarJugador(jugador);
        }

        public Formsala CrearSala(Jugador jugador)
        {
            return servidor.CrearSala(jugador);
        }

        public void CerrarSala(Formsala sala)
        {
            servidor.CerrarSala(sala);
        }

        public List<Jugador> ObtenerJugadoresActivos()
        {
            return pool.GetJugadoresEnUso();
        }
    }
}
