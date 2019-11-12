using System.Collections.Generic;
using Narchitect.Dot.Uml;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class AssociationDependencyAnalyzer : IDependencyAnalyzer
    {
        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            var dependencies = new List<Dependency>();
            foreach (var field in classModel.Fields)
            {
                var dependency = new Dependency(classModel.Name, field.TypeName, UmlEdgeType.Association);
                dependencies.Add(dependency);
            }
            foreach (var property in classModel.Properties)
            {
                var dependency = new Dependency(classModel.Name, property.TypeName, UmlEdgeType.Association);
                dependencies.Add(dependency);
            }
            return dependencies;
        }
    }
}
