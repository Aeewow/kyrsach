using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace kyrsach
{
    public class balls : IImpactPoint
    {
        public int R;
        public Color pen;
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(pen, 4), X - R / 2, Y - R / 2, R, R);
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы


            if (r + particle.Radius < R / 2)  // если частица оказалось внутри окружности
            {
                particle.FromColor = pen;
            }


        }
    }
}