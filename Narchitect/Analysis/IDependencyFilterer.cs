using System.Collections.Generic;

namespace Narchitect.Analysis
{
    public interface IDependencyFilterer
    {
        IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependencies);
    }
}
