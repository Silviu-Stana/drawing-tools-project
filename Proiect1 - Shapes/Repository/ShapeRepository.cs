using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes.Repository
{
    public class ShapeRepository : IShapeRepository
    {
        public void SaveShapes(List<Shape> shapes)
        {
            //save objects JSON disk
        }
        public List<Shape> LoadShapes()
        {
            //load JSON shapes from disk
            return new List<Shape>();
        }
    }
}
