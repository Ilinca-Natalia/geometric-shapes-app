using GeometricShapes.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace GeometricShapes.DataAccess
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly string _filePath = "shapes.json";

        public void SaveShapes(List<Shape> shapes)
        {
            var json = JsonConvert.SerializeObject(shapes, Formatting.Indented,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(_filePath, json);
        }

        public List<Shape> LoadShapes()
        {
            if (!File.Exists(_filePath))
                return new List<Shape>();

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Shape>>(json,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}