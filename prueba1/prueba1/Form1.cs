using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba1
{
    public partial class Form1 : Form

    {
        private Image originalImage;
        private float angle = 0f;
        private Timer rotationTimer;

        
        private SoundPlayer oiegelda;
        public Form1()
        {
            InitializeComponent();
            oiegelda=new SoundPlayer(Properties.Resources.videoplayback);
            // Cargar la imagen desde recursos (ajustá el nombre real del recurso)
            originalImage = Properties.Resources.download;

            // Configurar el PictureBox
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.BackColor = Color.Transparent;

            // Inicializar el Timer
            rotationTimer = new Timer();
            rotationTimer.Interval = 20;
            rotationTimer.Tick += RotationTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            oiegelda.Play();
            rotationTimer.Start();
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            angle += 10f; // Ajustá la velocidad
            if (angle >= 360f)
                angle = 0f;

            pictureBox1.Invalidate(); // Forzar redibujo
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            Graphics g = e.Graphics;
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-originalImage.Width / 2, -originalImage.Height / 2);
            g.DrawImage(originalImage, new Point(0, 0));
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
