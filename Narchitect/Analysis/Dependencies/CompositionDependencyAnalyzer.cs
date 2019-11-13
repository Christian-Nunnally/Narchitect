using System.Collections.Generic;
using Narchitect.Dot.Uml;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class CompositionDependencyAnalyzer : IDependencyAnalyzer
    {
        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            var dependencies = new List<Dependency>();
            foreach (var instantiatedTypeNames in classModel.InstantiatedTypeNames)
            {
                var dependency = new Dependency(classModel.Name, instantiatedTypeNames, UmlEdgeType.Composition);
                dependencies.Add(dependency);
            }
            return dependencies;
        }
    }
}
