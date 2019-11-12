using System.Collections.Generic;
using Narchitect.Dot.Uml;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class DependencyDependencyAnalyzer : IDependencyAnalyzer
    {
        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            var dependencies = new List<Dependency>();
            foreach (var method in classModel.Methods)
            {
                foreach (var paramType in method.ParameterTypeNames)
                {
                    var dependency = new Dependency(classModel.Name, paramType, UmlEdgeType.Dependency);
                    dependencies.Add(dependency);
                }
            }
            return dependencies;
        }
    }
}
