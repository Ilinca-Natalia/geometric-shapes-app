using System.Drawing;

namespace GeometricShapes.Core
{
    public interface IMovable
    {
        void Move(int deltaX, int deltaY);
    }
}