using System.Collections.Generic;
using System.Linq;
using Narchitect.Dot.Uml;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class AssociationDependencyAnalyzer : IDependencyAnalyzer
    {
        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            var dependencies = new List<Dependency>();
            var fieldsAndProperties = classModel.Fields.Concat<MemberModel>(classModel.Properties);
            foreach (var member in fieldsAndProperties)
            {
                foreach (var typeName in member.TypeNames)
                {
                    var dependency = new Dependency(classModel.Name, typeName, UmlEdgeType.Association);
                    dependencies.Add(dependency);
                }
            }
            return dependencies;
        }
    }
}
