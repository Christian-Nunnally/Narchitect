
namespace Narchitect.Dot.Uml
{
    public class UmlDotGraphFactory
    {
        public DotGraph CreateUmlDotGraph()
        {
            var graph = new DotGraph();
            graph.StyleProperties["fontname"] = "Segoe UI";
            graph.StyleProperties["fontsize"] = "8";
            graph.StyleProperties["rankdir"] = "BT";

            graph.DefaultNodeStyleProperties["fontname"] = "Segoe UI";
            graph.DefaultNodeStyleProperties["fontsize"] = "8";
            graph.DefaultNodeStyleProperties["shape"] = "record";
            graph.DefaultNodeStyleProperties["margin"] = "0.1";
            graph.DefaultNodeStyleProperties["width"] = "0";
            graph.DefaultNodeStyleProperties["height"] = "0.22";

            graph.DefaultEdgeStyleProperties["fontname"] = "Segoe UI";
            graph.DefaultEdgeStyleProperties["fontsize"] = "8";
            return graph;
        }
    }
}
