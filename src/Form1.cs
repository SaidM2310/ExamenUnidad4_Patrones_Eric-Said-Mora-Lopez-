using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace examen
{
    public partial class Form1 : Form
    {
        private ControladorJuego controlador;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            controlador = new ControladorJuego();

            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Lobby de jugadores";
            this.BackColor = Color.WhiteSmoke;

        
            Button btnAgregar = new Button();
            btnAgregar.Text = "Conectar jugador";
            btnAgregar.Location = new Point(350, 400);
            btnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(btnAgregar);
            
            Button btnDesconectar = new Button();
            btnDesconectar.Text = "Desconectar jugador";
            btnDesconectar.Location = new Point(350, 20);
            btnDesconectar.Anchor = AnchorStyles.Top;
            btnDesconectar.Click += BtnDesconectar_Click;
            this.Controls.Add(btnDesconectar);

            CrearSalas();
        }

        private void CrearSalas()
        {
            Color colorSala = Color.LightBlue;
            Size tamañoSala = new Size(150, 100);

            Point[] posiciones = new Point[]
            {
                new Point(0, 0),       
                new Point(650, 0),     
                new Point(0, 175),     
                new Point(650, 175),   
                new Point(0, 350),     
                new Point(650, 350)   
            };

            for (int i = 0; i < posiciones.Length; i++)
            {
                Panel sala = new Panel();
                sala.Size = tamañoSala;
                sala.Location = posiciones[i];
                sala.BackColor = colorSala;
                sala.BorderStyle = BorderStyle.FixedSingle;

                Label label = new Label();
                label.Text = "Sala de juego";
                label.ForeColor = Color.Black;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                sala.Controls.Add(label);
                this.Controls.Add(sala);
                sala.BringToFront();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Jugador j = controlador.ConectarJugador(this);
            if (j != null)
            {
                j.Cuerpo.Location = new Point(
                    rnd.Next(180, 500),
                    rnd.Next(0, 400)
                );
            }
        }

        private void BtnDesconectar_Click(object sender, EventArgs e)
        {
            var jugadoresActivos = controlador.ObtenerJugadoresActivos();
            if (jugadoresActivos.Count == 0)
            {
                MessageBox.Show("No hay jugadores conectados.");
                return;
            }

            Jugador jugador = jugadoresActivos[jugadoresActivos.Count - 1];
            controlador.DesconectarJugador(this, jugador);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var jugador in controlador.ObtenerJugadoresActivos())
            {
                jugador.Mover(e.KeyCode);
                DetectarEntradaASala(jugador);
            }
        }

        private void DetectarEntradaASala(Jugador jugador)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel && ctrl.BackColor == Color.LightBlue)
                {
                    if (jugador.Cuerpo.Bounds.IntersectsWith(ctrl.Bounds))
                    {
                        Formsala sala = controlador.CrearSala(jugador);
                        sala.Show();
                        return;
                    }
                }
            }
        }
    }
}
