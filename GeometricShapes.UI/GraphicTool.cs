using GeometricShapes.Core;
using GeometricShapes.DataAccess;
using System.Collections.Generic;
using System.Drawing;

namespace GeometricShapes.UI
{
    public class GraphicTool
    {
        public List<Shape> Shapes { get; private set; }
        public IShapeRepository ShapeRepository { get; set; }

        public GraphicTool(IShapeRepository repository)
        {
            Shapes = new List<Shape>();
            ShapeRepository = repository;
        }

        public void AddShape(Shape shape) => Shapes.Add(shape);

        public void RemoveShape(Shape shape) => Shapes.Remove(shape);

        public void DrawAllShapes(Graphics g)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public void MoveShape(Shape shape, int deltaX, int deltaY) => shape.Move(deltaX, deltaY);

        public void ResizeShape(Shape shape, float factor) => shape.Resize(factor);

        public void SaveShapes() => ShapeRepository.SaveShapes(Shapes);

        public void LoadShapes() => Shapes = ShapeRepository.LoadShapes();
    }
}