using factorypattern.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorypattern.Entities
{
    class Present : Toy
    {
        public SolidBrush BoxColor { get; private set; }
        public SolidBrush RibbonColor { get; private set; }

        public Present(Color color)
        {
            BoxColor = new SolidBrush(color);
        }


        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BoxColor, 0, 0, Width, Height);
        }
    }
}
