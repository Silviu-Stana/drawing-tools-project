using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1___Shapes.Repository
{
    public class JSONShapeRepository : IShapeRepository
    {
        public void SaveShapes(List<Shape> shapes)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Save Shapes JSON File",
                FileName = "shapes.json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonConvert.SerializeObject(shapes, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        public List<Shape> LoadShapes()
        {
            List<Shape> shapes = new List<Shape>();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Open Shapes JSON File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);

                // Deserialize the raw JSON into a JArray
                JArray jsonArray = JArray.Parse(json);

                // Iterate over each object in the array and instantiate the correct shape based on the JsonType
                foreach (var item in jsonArray)
                {
                    string jsonType = item["JsonType"]?.ToString();
                    Shape shape = null;

                    switch (jsonType)
                    {
                        case "Square":
                            shape = JsonConvert.DeserializeObject<Square>(item.ToString());
                            break;
                        case "Circle":
                            shape = JsonConvert.DeserializeObject<Circle>(item.ToString());
                            break;
                        case "Line":
                            shape = JsonConvert.DeserializeObject<Line>(item.ToString());
                            break;
                        case "Triangle":
                            shape = JsonConvert.DeserializeObject<Triangle>(item.ToString());
                            break;
                        default:
                            throw new JsonSerializationException($"Unknown JsonType: {jsonType}");
                    }

                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }
            }

            return shapes;
        }
    }
}
