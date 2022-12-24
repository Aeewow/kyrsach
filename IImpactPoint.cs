using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsach
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public Color color;
        public int schet = 0;

        public abstract void ImpactParticle(Particle particle);



        public virtual void Render(Graphics g)
        {

        }
    }
}
