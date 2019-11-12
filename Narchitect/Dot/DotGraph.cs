using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narchitect.Dot
{
    public class DotGraph : DotObject
    {
        public IEnumerable<DotNode> Nodes { get; set; } = new DotNode[0];

        public IEnumerable<DotEdge> Edges { get; set; } = new DotEdge[0];

        public IEnumerable<DotElement> Elements => Nodes.Concat<DotElement>(Edges);

        public Dictionary<string, string> DefaultNodeStyleProperties { get; } = new Dictionary<string, string>();

        public Dictionary<string, string> DefaultEdgeStyleProperties { get; } = new Dictionary<string, string>();

        public string GenerateDotString()
        {
            var builder = new StringBuilder();
            builder.Append("digraph uml\n");
            builder.Append("{\n");
            BuildProperties(builder, StyleProperties, prefix: "\t");
            builder.Append("\n");
            BuildDotElementString(builder, "node", DefaultNodeStyleProperties);
            builder.Append("\n");
            BuildDotElementString(builder, "edge", DefaultEdgeStyleProperties);
            builder.Append("\n");
            BuildElements(builder);
            builder.Append("\n}");
            return builder.ToString();
        }

        private void BuildElements(StringBuilder builder)
        {
            foreach (var element in Elements)
            {
                builder.Append($"{element.GenerateDotString()}\n");
            }
        }
    }
}
