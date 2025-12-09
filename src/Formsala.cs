using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace examen
{
    public partial class Formsala : Form
    {
        public List<Jugador> Jugadores { get; private set; } = new List<Jugador>();
        private Label lblEstado;

        private Button btnPiedra1, btnPapel1, btnTijera1;
        private Button btnPiedra2, btnPapel2, btnTijera2;

        private string eleccion1 = null, eleccion2 = null;

        private IEstadoSala estadoActual; 

        public Formsala()
        {
            InitializeComponent();
            this.Text = "Sala de Juego - Piedra, Papel o Tijera";
            this.Size = new Size(500, 400);

            CrearInterfaz();

            CambiarEstado(new Esperando());
        }

        private void CrearInterfaz()
        {
            lblEstado = new Label();
            lblEstado.Dock = DockStyle.Top;
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            lblEstado.Font = new Font("Arial", 16, FontStyle.Bold);
            lblEstado.Height = 60;
            lblEstado.Text = "Esperando jugadores...";
            this.Controls.Add(lblEstado);
        }

        public void CambiarEstado(IEstadoSala nuevoEstado)
        {
            estadoActual = nuevoEstado;
            estadoActual.EntrarEstado(this);
        }

        public void AgregarJugador(Jugador jugador)
        {
            estadoActual.AgregarJugador(this, jugador);
        }

        public void MostrarBotones()
        {
            btnPiedra1 = CrearBotonConImagen(Properties.Resources.piedra, 100, 250, (s, e) => Elegir(1, "Piedra"));
            btnPapel1 = CrearBotonConImagen(Properties.Resources.papel, 200, 250, (s, e) => Elegir(1, "Papel"));
            btnTijera1 = CrearBotonConImagen(Properties.Resources.tijera, 300, 250, (s, e) => Elegir(1, "Tijera"));

            btnPiedra2 = CrearBotonConImagen(Properties.Resources.piedra, 100, 100, (s, e) => Elegir(2, "Piedra"));
            btnPapel2 = CrearBotonConImagen(Properties.Resources.papel, 200, 100, (s, e) => Elegir(2, "Papel"));
            btnTijera2 = CrearBotonConImagen(Properties.Resources.tijera, 300, 100, (s, e) => Elegir(2, "Tijera"));

            Controls.AddRange(new Control[] { btnPiedra1, btnPapel1, btnTijera1, btnPiedra2, btnPapel2, btnTijera2 });

        }

        private Button CrearBotonConImagen(Image imagen, int x, int y, EventHandler evento)
        {
            Button b = new Button();
            b.Size = new Size(80, 80);                 
            b.Location = new Point(x, y);
            b.BackgroundImage = imagen;               
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.Text = "";                            
            b.Click += evento;
            return b;
        }

        private void Elegir(int jugador, string eleccion)
        {
            estadoActual.JugadorElige(this, jugador, eleccion);
        }


        public void ActualizarEstadoLabel(string texto)
        {
            lblEstado.Text = texto;
        }

        public void GuardarEleccion(int jugador, string eleccion)
        {
            if (jugador == 1) eleccion1 = eleccion;
            else eleccion2 = eleccion;
            DeshabilitarBotones(jugador);
        }

        public bool EleccionesCompletas()
        {
            return eleccion1 != null && eleccion2 != null;
        }

       
        private int rondasJugador1 = 0;
        private int rondasJugador2 = 0;

        public void DeterminarGanador()
        {
            string resultado;

            if (eleccion1 == eleccion2)
                resultado = "Empate";
            else if ((eleccion1 == "Piedra" && eleccion2 == "Tijera") ||
                     (eleccion1 == "Papel" && eleccion2 == "Piedra") ||
                     (eleccion1 == "Tijera" && eleccion2 == "Papel"))
            {
                resultado = "Jugador 1 gana la ronda";
                rondasJugador1++;
            }
            else
            {
                resultado = "Jugador 2 gana la ronda";
                rondasJugador2++;
            }

            MessageBox.Show(resultado, "Resultado de la ronda");

            ActualizarEstadoLabel($"Jugador 1: {rondasJugador1} | Jugador 2: {rondasJugador2}");

            if (rondasJugador1 >= 2)
            {
                MessageBox.Show("Jugador 1 GANA la partida!", "Ganador Final");
                this.Close();
            }
            else if (rondasJugador2 >= 2)
            {
                MessageBox.Show("Jugador 2 GANA la partida!", "Ganador Final");
                this.Close();
            }
            else
            {
                eleccion1 = null;
                eleccion2 = null;

                btnPiedra1.Enabled = btnPapel1.Enabled = btnTijera1.Enabled = true;
                btnPiedra2.Enabled = btnPapel2.Enabled = btnTijera2.Enabled = true;
            }
        }
        private Image HacerGris(Image original)
        {
            Bitmap gris = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = ((Bitmap)original).GetPixel(x, y);
                    int tono = (pixel.R + pixel.G + pixel.B) / 3;
                    gris.SetPixel(x, y, Color.FromArgb(pixel.A, tono, tono, tono));
                }
            }

            return gris;
        }


        private void DeshabilitarBotones(int jugador)
        {
            if (jugador == 1 && btnPiedra1 != null)
                btnPiedra1.Enabled = btnPapel1.Enabled = btnTijera1.Enabled = false;
            else if (jugador == 2 && btnPiedra2 != null)
                btnPiedra2.Enabled = btnPapel2.Enabled = btnTijera2.Enabled = false;
        }
    }
}
