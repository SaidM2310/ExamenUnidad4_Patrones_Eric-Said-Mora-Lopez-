using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen
{
    public class Jugador
    {
        public Panel Cuerpo { get; private set; }
        private int velocidad = 10;

        private Keys arriba;
        private Keys abajo;
        private Keys izquierda;
        private Keys derecha;

        public bool Activo { get; set; }

        public Jugador(Keys arriba, Keys abajo, Keys izquierda, Keys derecha)
        {
            this.arriba = arriba;
            this.abajo = abajo;
            this.izquierda = izquierda;
            this.derecha = derecha;

            Cuerpo = new Panel();
            Cuerpo.Size = new Size(30, 30);
            Cuerpo.BackColor = Color.LimeGreen;
        }

        public void Mover(Keys tecla)
        {
            if (!Activo) return;

            int x = Cuerpo.Left;
            int y = Cuerpo.Top;

            if (tecla == arriba) y -= velocidad;
            if (tecla == abajo) y += velocidad;
            if (tecla == izquierda) x -= velocidad;
            if (tecla == derecha) x += velocidad;

            Cuerpo.Location = new Point(x, y);
        }
    }
}
