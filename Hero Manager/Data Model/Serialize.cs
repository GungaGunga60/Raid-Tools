using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Manager.Data_Model
{
    internal static class Serialize
    {
        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }

        private static bool IsLeafType(Type type)
        {
            if (type.IsValueType)
                return true;

            if (type == typeof(String))
                return true;

            return false;
        }
        public static string ToText(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(obj.GetType().FullName);
            sb.AppendLine("Fields:");
            foreach (var field in obj.GetType().GetFields())
            {
                if (IsLeafType(field.FieldType))
                {
                    sb.AppendFormat("{0}: {1}{2}", field.Name, field.GetValue(obj), Environment.NewLine);
                }
                else
                {
                    object? fieldValue = field.GetValue(obj);
                    if (fieldValue != null)
                    {
                        if (fieldValue is Array)
                        {
                            Array a = fieldValue as Array;
                            foreach (var item in a)
                            {
                                sb.AppendLine(ToText(item));
                            }
                        }
                        else
                        {
                            sb.AppendLine(ToText((object)fieldValue));
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}
