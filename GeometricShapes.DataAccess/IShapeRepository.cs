using GeometricShapes.Core;
using System.Collections.Generic;

namespace GeometricShapes.DataAccess
{
    public interface IShapeRepository
    {
        void SaveShapes(List<Shape> shapes);
        List<Shape> LoadShapes();
    }
}