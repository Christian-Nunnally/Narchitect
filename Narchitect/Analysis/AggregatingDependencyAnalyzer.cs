using System;
using System.Collections.Generic;
using System.Linq;
using Narchitect.Model;

namespace Narchitect.Analysis
{
    public class AggregatingDependencyAnalyzer : IDependencyAnalyzer
    {
        private IList<IDependencyAnalyzer> _composedAnalyzers = new List<IDependencyAnalyzer>();

        public IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel)
        {
            return _composedAnalyzers.SelectMany(a => a.AnalyzeForDependencies(classModel));
        }

        public void AddAnalyzer(IDependencyAnalyzer analyzer)
        {
            _composedAnalyzers.Add(analyzer);
        }
    }
}
