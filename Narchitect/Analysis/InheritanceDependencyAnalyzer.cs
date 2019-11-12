using System.Collections.Generic;
using Narchitect.Dot.Uml;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class InheritanceDependencyAnalyzer : IDependencyAnalyzer
    {
        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            var dependencies = new List<Dependency>();
            if (classModel.BaseTypeNames is object)
            {
                foreach (var baseTypeName in classModel.BaseTypeNames)
                {
                    var dependency = new Dependency(classModel.Name, baseTypeName, UmlEdgeType.Inheritence);
                    dependencies.Add(dependency);
                }
            }
            return dependencies;
        }
    }
}
