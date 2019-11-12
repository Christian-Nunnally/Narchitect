using System.Collections.Generic;
using System.Text;

namespace Narchitect.Dot
{
    public class DotObject
    {
        public IDictionary<string, string> StyleProperties { get; } = new Dictionary<string, string>();

        protected void BuildDotElementString(StringBuilder builder, string elementName, IDictionary<string, string> elementProperties)
        {
            builder.Append($"\t{elementName}\n");
            if (elementProperties.Count > 0)
            {
                builder.Append("\t[\n");
                BuildProperties(builder, elementProperties);
                builder.Append("\t]\n");
            }
        }

        protected void BuildProperties(StringBuilder builder, IDictionary<string, string> properties, string prefix = "\t\t")
        {
            foreach (var styleProperty in properties)
            {
                builder.Append($"{prefix}{styleProperty.Key} = \"{styleProperty.Value}\"\n");
            }
        }
    }
}