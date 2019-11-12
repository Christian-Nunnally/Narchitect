
namespace Narchitect.Dot.Uml
{
    public class UmlDotGraphFactory
    {
        public DotGraph CreateUmlDotGraph()
        {
            var graph = new DotGraph();
            graph.StyleProperties["fontname"] = "Consolas"; // "Bitstream Vera Sans";
            graph.StyleProperties["fontsize"] = "8";

            graph.DefaultNodeStyleProperties["fontname"] = "Consolas"; //"Bitstream Vera Sans";
            graph.DefaultNodeStyleProperties["fontsize"] = "8";
            graph.DefaultNodeStyleProperties["shape"] = "record";

            graph.DefaultEdgeStyleProperties["fontname"] = "Consolas"; //"Bitstream Vera Sans";
            graph.DefaultEdgeStyleProperties["fontsize"] = "8";
            return graph;
        }
    }
}
