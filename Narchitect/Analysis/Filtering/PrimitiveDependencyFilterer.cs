using System.Collections.Generic;
using System.Linq;

namespace Narchitect.Analysis
{
    /// <summary>
    /// Filters out dependencies on primitive types.
    /// </summary>
    public class PrimitiveDependencyFilterer : IDependencyFilterer
    {
        public IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependancies)
        {
            return dependancies.Where(d => char.IsUpper(d.ToIdentifier[0]));
        }
    }
}
