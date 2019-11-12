using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Narchitect.Analysis;
using Narchitect.Dot;
using Narchitect.Dot.Uml;
using Narchitect.SyntaxTreeParsing;

namespace Narchitect
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ClassFilePath = "C:/DSW/Source/MocCommon/MocCommon/SourceModel/BreakpointCondition.cs";
            const string DotFilePath = @"C:/Users/cnunnall/Desktop/Dot/dot.dot";
            const string SvgFilePath = @"C:/Users/cnunnall/Desktop/Dot/uml.svg";

            // Clean up from before
            if (File.Exists(DotFilePath)) File.Delete(DotFilePath);

            // Parse the syntax tree to find all classes
            CompilationUnitSyntax root = ClassFileParser.Parse(ClassFilePath);
            var syntaxTreeParser = new SyntaxTreeParser();
            var classParser = new ClassSyntaxParser();
            syntaxTreeParser.RegisterParsingStratagy(classParser);
            syntaxTreeParser.Parse(root);
            var classes = classParser.ParsedClasses;

            // Analyze classes for dependencies
            var analyzer = new AggregatingDependencyAnalyzer();
            analyzer.AddAnalyzer(new InheritanceDependencyAnalyzer());
            analyzer.AddAnalyzer(new AssociationDependencyAnalyzer());
            analyzer.AddAnalyzer(new DependencyDependencyAnalyzer());
            var dependencies = classes.SelectMany(analyzer.AnalyzeForDependencies);

            // Filter out dependencies that we dont care about
            var dependencyFilterer = new AggregatingDependencyFilterer();
            dependencyFilterer.AddFilterer(new PrimitiveDependencyFilterer());
            dependencyFilterer.AddFilterer(new DuplicateDependencyFilterer());
            dependencyFilterer.AddFilterer(new PrecedenceDependencyFilterer());
            var filteredDependencies = dependencyFilterer.Filter(dependencies);

            // Convert classes to uml nodes
            var umlNodeFactory = new UmlDotNodeFactory();
            var umlNodes = classes.Select(umlNodeFactory.CreateFromClass);

            // Convert dependencies to uml nodes
            var umlEdgeFactory = new UmlDotEdgeFactory();
            var umlEdges = filteredDependencies.Select(d => umlEdgeFactory.CreateUmlDotEdge(d.EdgeType, d.FromIdentifier, d.ToIdentifier));

            // Create uml graph object
            var umlDotGraphFactory = new UmlDotGraphFactory();
            var umlGraph = umlDotGraphFactory.CreateUmlDotGraph();
            umlGraph.Nodes = umlNodes;
            umlGraph.Edges = umlEdges;

            // Generate and write dot file
            var dotString = umlGraph.GenerateDotString();
            File.WriteAllText(DotFilePath, dotString);

            // Convert dot file to svg
            var dotToSvgGenerator = new DotSvgGenerator();
            dotToSvgGenerator.GenerateSVGFromDot(DotFilePath, SvgFilePath);

            // 5. Open SVG
            Process.Start(SvgFilePath);
        }
    }
}
