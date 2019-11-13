using System.Collections.Generic;
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
            // Debugger.Launch();
            string tempDirectory = Path.GetTempPath().Replace(@"\\", @"\");
            string DotFilePath = tempDirectory + "dot.dot";
            string SvgFilePath = tempDirectory + "uml.svg";

            // Clean up from before
            if (File.Exists(DotFilePath)) File.Delete(DotFilePath);
            List<Model.ClassModel> classes = new List<Model.ClassModel>();
            foreach (string classFilePath in args)
            {
                // Parse the syntax tree to find all classes
                CompilationUnitSyntax root = ClassFileParser.Parse(classFilePath);
                var syntaxTreeParser = new SyntaxTreeParser();
                var classParser = new ClassSyntaxParser();
                syntaxTreeParser.RegisterParsingStratagy(classParser);
                syntaxTreeParser.Parse(root);
                classes.AddRange(classParser.ParsedClasses);
            }

            // Analyze classes for dependencies
            var analyzer = new AggregatingDependencyAnalyzer();
            analyzer.AddAnalyzer(new InheritanceDependencyAnalyzer());
            analyzer.AddAnalyzer(new AssociationDependencyAnalyzer());
            analyzer.AddAnalyzer(new DependencyDependencyAnalyzer());
            analyzer.AddAnalyzer(new CompositionDependencyAnalyzer());
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
