using kyrsach;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kyrsach
{
    public class RainEater : IImpactPoint
    {
        public int Radius = 100;
        public int Count = 0;
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);
            var currentPacticle = (particle as Particle);
            if (r + particle.Radius < Radius / 2)
            {
                currentPacticle.Radius = 0;
                currentPacticle.Life = 0;
                Count += 1;
            }
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                 new Pen(Color.Red, 2),
                 X - Radius / 2,
                 Y - Radius / 2,
                 Radius,
                 Radius);
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(
                 $"Сборано: \n{Count}",
                 new Font("Verdana", 14),
                 new SolidBrush(Color.OrangeRed),
                 X, Y, stringFormat);

        }
    }
}
