using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes
{
    public interface IShapeRepository
    {
        void SaveShapes(List<Shape> shapes);  // Save the list of shapes to storage
        List<Shape> LoadShapes();             // Load the list of shapes from storage
    }
}
