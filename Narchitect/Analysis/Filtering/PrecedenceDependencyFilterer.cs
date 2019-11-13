using System;
using System.Collections.Generic;
using System.Linq;

namespace Narchitect.Analysis
{
    /// <summary>
    /// Filters out dependencies on primitive types.
    /// </summary>
    public class PrecedenceDependencyFilterer : IDependencyFilterer
    {
        public IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependencies)
        {
            var filteredDependecies = new List<Dependency>(dependencies);
            for (int i = 0; i < filteredDependecies.Count; i++)
            {
                var dependency = filteredDependecies[i];
                var similarDependencies = dependencies.Where(IsDependencyTheSame(dependency));

                foreach (var similarDependency in similarDependencies)
                {
                    if (HasPrecedence(dependency, similarDependency))
                    {
                        filteredDependecies.Remove(similarDependency);
                    }
                    else
                    {
                        filteredDependecies.Remove(dependency);
                    }
                }
            }
            return filteredDependecies;
        }

        private Func<Dependency, bool> IsDependencyTheSame(Dependency firstDependency) => secondDependency =>
        {
            return (firstDependency.FromIdentifier == secondDependency.FromIdentifier
                && firstDependency.ToIdentifier == secondDependency.ToIdentifier
                && firstDependency.EdgeType != secondDependency.EdgeType) 
                || (firstDependency.FromIdentifier == secondDependency.ToIdentifier
                && firstDependency.ToIdentifier == secondDependency.FromIdentifier
                && ((firstDependency.EdgeType != secondDependency.EdgeType)
                && (firstDependency.EdgeType == Dot.Uml.UmlEdgeType.Composition || secondDependency.EdgeType == Dot.Uml.UmlEdgeType.Composition)));
        };

        private bool HasPrecedence(Dependency dependency, Dependency otherDependency)
        {
            return dependency.EdgeType < otherDependency.EdgeType;
        }
    }
}
