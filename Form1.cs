using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kyrsach
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        balls point1; // добавил поле под первую точку
        balls point2;
        balls point3;
        balls point4;

        public Form1()
        {          
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new LinEmmiter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f,
                SpeedMin = 1,
                SpeedMax = 30
            };
            emitters.Add(emitter);


            point1 = new balls
            {
                X = picDisplay.Width / 2 + 300,
                Y = 150,
                color = Color.Purple

            };
            point2 = new balls
            {
                X = picDisplay.Width / 2 - 150,
                Y = 150,
                color = Color.Aqua
            };
            point3 = new balls
            {
                X = picDisplay.Width / 2 + 150,
                Y = 150,
                color = Color.Violet
            };
            point4 = new balls
            {
                X = picDisplay.Width / 2 - 300,
                Y = 150,
                color = Color.Aquamarine
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            emitter.impactPoints.Add(point3);
            emitter.impactPoints.Add(point4);
        }

        private void picDisplay_Click(object sender, EventArgs e)
        {

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }
        
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = tbDirection.Value;
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (var p in emitter.impactPoints)
            {
                if (p is balls)
                {
                    (p as balls).rad = SizeTrack.Value;
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                emitter.impactPoints.Add(new balls
                {
                    X = e.X,
                    Y = e.Y,
                    color = Color.Red
                });
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (var impactPoint in emitter.impactPoints)
                {
                    if (!(impactPoint is balls ball)) continue;
                    if (!(impactPoint.color == Color.Blue)) continue;
                    if (!(Math.Abs(ball.X - e.X) <= ball.rad) || !(Math.Abs(ball.Y - e.Y) <= ball.rad))
                        continue;
                    emitter.impactPoints.Remove(ball);
                    break;
                }
            }
        }
    }
}