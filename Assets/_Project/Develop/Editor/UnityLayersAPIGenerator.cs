using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets._Project.Develop.Editor
{
    public class UnityLayersAPIGenerator
    {
        private struct LayerInfo
        {
            public string LayerName;
            public string ModifiedLayerName;
            public string ModifiedLayerMaskName;
        }

        private static string OutputPath
            => Path.Combine(Application.dataPath, "_Project/Develop/Runtime/Utilities/LayersConstsGenerated/UnityLayers.cs");

        [InitializeOnLoadMethod]
        [MenuItem("Tools/GenerateUnityLayers")]
        private static void Generate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using UnityEngine;");

            sb.AppendLine($"namespace Assets._Project.Develop.Runtime.Utilities.LayersConstsGenerated");
            sb.AppendLine("{");

            sb.AppendLine($"\tpublic static class UnityLayers");
            sb.AppendLine("\t{");

            List<LayerInfo> layers = new();

            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                if (string.IsNullOrEmpty(layerName) == false)
                {
                    string modifiedLayerName = AddSuffix(layerName, "Layer");
                    string modifiedLayerMaskName = AddSuffix(layerName, "LayerMask");

                    layers.Add(new LayerInfo
                    {
                        LayerName = layerName,
                        ModifiedLayerName = DeleteSpace(modifiedLayerName),
                        ModifiedLayerMaskName = DeleteSpace(modifiedLayerMaskName)
                    });
                }
            }

            foreach(LayerInfo layer in layers)
                sb.AppendLine($"\tpublic static readonly int {layer.ModifiedLayerName} = LayerMask.NameToLayer(\"{layer.LayerName}\");");

            sb.AppendLine();

            foreach (LayerInfo layer in layers)
                sb.AppendLine($"\tpublic static readonly int {layer.ModifiedLayerMaskName} = 1 << {layer.ModifiedLayerName};");

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static string AddSuffix(string str, string suffix) => suffix + str;

        private static string DeleteSpace(string str) => str.Replace(" ", "");
    }
}

