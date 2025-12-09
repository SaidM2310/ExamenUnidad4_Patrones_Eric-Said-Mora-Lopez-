using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen
{
    public interface IEstadoSala
    {
        void AgregarJugador(Formsala sala, Jugador jugador);
        void JugadorElige(Formsala sala, int jugador, string eleccion);
        void EntrarEstado(Formsala sala);
    }
}
