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
        List<CountEater> gravityPoints = new List<CountEater>(); //список точек поглощения
        balls cirlce1, cirlce2, cirlce3, cirlce4, cirlce5, cirlce6, cirlce7;


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

            cirlce2= new balls
            {
                X = picDisplay.Width / 2 ,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen=Color.Red
            };
            cirlce4 = new balls
            {
                X = picDisplay.Width / 4,
                Y = picDisplay.Height*2 / 5,
                R = 70,
                pen = Color.Yellow
            };
            cirlce3 = new balls
            {
                X = picDisplay.Width * 4 / 5+15,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen = Color.Lime
            };
            cirlce1 = new balls
            {
                X = picDisplay.Width / 5 - 10,
                Y = picDisplay.Height * 7 / 10,
                R = 100,
                pen = Color.Blue
            };
            emitter.impactPoints.Add(cirlce1);
            emitter.impactPoints.Add(cirlce2);
            emitter.impactPoints.Add(cirlce3);
            emitter.impactPoints.Add(cirlce4);
            

            // привязываем поля к эмиттеру
            
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
                    (p as balls).R = SizeTrack.Value;
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
            var x = Cursor.Position.X;
            var y = Cursor.Position.Y;
            CountEater point = new CountEater
            {
                X = e.X,
                Y = e.Y,
            };
            gravityPoints.Add(point);
            emitter.impactPoints.Add(point);
        }

        private void trackBar1_Scroll_2(object sender, EventArgs e)
        {
            cirlce1.X = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            cirlce2.X = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            cirlce3.X = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            cirlce4.X = trackBar4.Value;
        }
    }
}