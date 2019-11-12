using System.Collections.Generic;

namespace Narchitect.Analysis
{
    /// <summary>
    /// Aggregates multiple <see cref="IDependencyFilterer"/> to create a new combined filter.
    /// </summary>
    public class AggregatingDependencyFilterer : IDependencyFilterer
    {
        private readonly IList<IDependencyFilterer> _aggregatedDependencyFilterers = new List<IDependencyFilterer>();

        public IEnumerable<Dependency> Filter(IEnumerable<Dependency> dependancies)
        {
            
            var includedDependencies = dependancies;
            foreach (var filterer in _aggregatedDependencyFilterers)
            {
                includedDependencies = filterer.Filter(includedDependencies);
            }
            return includedDependencies;
        }

        public void AddFilterer(IDependencyFilterer filterer)
        {
            _aggregatedDependencyFilterers.Add(filterer);
        }
    }
}
