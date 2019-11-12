using System.Collections.Generic;
using System.Linq;

namespace Narchitect.Analysis
{
    /// <summary>
    /// Filters out duplicate dependencies.
    /// </summary>
    public class DuplicateDependencyFilterer : IDependencyFilterer
    {
        public IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependancies)
        {
            return dependancies.Distinct();
        }
    }
}
