using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    public class ServidorPartida
    {
        private static ServidorPartida instancia;
        private static readonly object bloqueo = new object();

        public List<Formsala> SalasActivas { get; private set; }

        private ServidorPartida()
        {
            SalasActivas = new List<Formsala>();
        }

        public static ServidorPartida Instancia
        {
            get
            {
                lock (bloqueo)
                {
                    if (instancia == null)
                        instancia = new ServidorPartida();
                    return instancia;
                }
            }
        }

        public Formsala CrearSala(Jugador jugador)
        {
            foreach (var sala in SalasActivas)
            {
                if (sala.Jugadores.Count == 1)
                {
                    sala.AgregarJugador(jugador);
                    return sala;
                }
            }

            Formsala nueva = new Formsala();
            nueva.AgregarJugador(jugador);
            SalasActivas.Add(nueva);
            return nueva;
        }

        public void CerrarSala(Formsala sala)
        {
            if (SalasActivas.Contains(sala))
                SalasActivas.Remove(sala);
        }

    }
}
