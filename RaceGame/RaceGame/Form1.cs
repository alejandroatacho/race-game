using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceGame
{
    public partial class Form1 : Form
    {
        Bitmap Backbuffer;
        Point Blockpoint = new Point(50, 50);
        Point BlockSpeed = new Point(0, 0);
        int DefaultBlockspeed = 10;
        float angle;
        int[] size = new int[2] {20, 20};

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);

            Timer GameTimer = new Timer();
            GameTimer.Interval = 1;
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            GameTimer.Start();

            this.ResizeEnd += new EventHandler(Form1_CreateBackBuffer);
            this.Load += new EventHandler(Form1_CreateBackBuffer);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                //BlockSpeed.X = -DefaultBlockspeed;
                angle += -10f;
            }
            else if (e.KeyCode == Keys.D)
            {
                //BlockSpeed.X = DefaultBlockspeed;
                angle += 10f;
            }
            else if (e.KeyCode == Keys.W)
            {
                BlockSpeed.Y = Convert.ToInt32(DefaultBlockspeed * (Math.Sin(DegtoRad(angle))));
                BlockSpeed.X = Convert.ToInt32(DefaultBlockspeed * (Math.Cos(DegtoRad(angle))));
            }
            else if (e.KeyCode == Keys.S)
            {
                BlockSpeed.Y = DefaultBlockspeed;
            }
        }
        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                BlockSpeed.Y = 0;
                BlockSpeed.X = 0;
            }
            else if (e.KeyCode == Keys.S)
            {
                BlockSpeed.Y = 0;
            }
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
           if (Backbuffer != null)
            {
                e.Graphics.DrawImageUnscaled(Backbuffer, Point.Empty);
            }
        }
        void Form1_CreateBackBuffer(object sender, EventArgs e)
        {
            if(Backbuffer != null)
            {
                Backbuffer.Dispose();
            }
            Backbuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        void Draw()
        {
            if (Backbuffer != null)
            {
                using (var g = Graphics.FromImage(Backbuffer))
                {
                    g.Clear(Color.White);
                    g.TranslateTransform(Blockpoint.X - size[0]/2.0f, Blockpoint.Y - size[1] / 2.0f);
                    g.RotateTransform(angle);
                    g.TranslateTransform(-Blockpoint.X - size[0] / 2.0f, -Blockpoint.Y - size[1] / 2.0f);
                    g.FillRectangle(Brushes.BlueViolet, Blockpoint.X, Blockpoint.Y, size[0], size[1]);
                }
                Invalidate();
            }
        }

        double DegtoRad(double deg)
        {
            return (Math.PI/180)*deg;
        }
        void GameTimer_Tick(object sender, EventArgs e)
        {
            Blockpoint.X += BlockSpeed.X;
            Blockpoint.Y += BlockSpeed.Y;
            Draw();
        }
    }
}

