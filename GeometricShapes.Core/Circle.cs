using System.Drawing;

namespace GeometricShapes.Core
{
    public class Circle : Shape, IDrawable, IMovable, IResizable
    {
        public int Radius { get; set; }

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(FillColor))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public override void Resize(float factor)
        {
            Radius = (int)(Radius * factor);
        }
    }
}