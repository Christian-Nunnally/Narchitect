using System.Collections.Generic;
using System.Linq;

namespace Narchitect.Analysis
{
    /// <summary>
    /// Filters out dependencies to self.
    /// </summary>
    public class SelfDependencyFilterer : IDependencyFilterer
    {
        public IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependancies)
        {
            return dependancies.Where(d => d.FromIdentifier != d.ToIdentifier);
        }
    }
}
