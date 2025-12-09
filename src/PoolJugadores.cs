using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    internal class PoolJugadores
    {
        private List<Jugador> jugadoresDisponibles = new List<Jugador>();
        private List<Jugador> jugadoresEnUso = new List<Jugador>();
        private int maxJugadores = 3;

        public PoolJugadores()
        {
            jugadoresDisponibles.Add(new Jugador(Keys.W, Keys.S, Keys.A, Keys.D));  // J1
            jugadoresDisponibles.Add(new Jugador(Keys.I, Keys.K, Keys.J, Keys.L));  // J2
            jugadoresDisponibles.Add(new Jugador(Keys.G, Keys.B, Keys.V, Keys.N));  // J3

        }

        public Jugador ObtenerJugador()
        {
            if (jugadoresEnUso.Count < maxJugadores && jugadoresDisponibles.Count > 0)
            {
                Jugador jugador = jugadoresDisponibles[0];
                jugadoresDisponibles.RemoveAt(0);
                jugador.Activo = true;
                jugadoresEnUso.Add(jugador);
                return jugador;
            }
            else
            {
                MessageBox.Show("No se pueden agregar más jugadores (máx. 3).");
                return null;
            }
        }

        public void LiberarJugador(Jugador jugador)
        {
            if (jugadoresEnUso.Contains(jugador))
            {
                jugador.Activo = false;
                jugadoresEnUso.Remove(jugador);
                jugadoresDisponibles.Add(jugador);
            }
        }

        public List<Jugador> GetJugadoresEnUso()
        {
            return jugadoresEnUso;
        }
    }
}
