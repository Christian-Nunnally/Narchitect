using Narchitect.Model;
using System.Collections.Generic;

namespace Narchitect.Analysis
{
    public interface IDependencyAnalyzer
    {
        IEnumerable<Dependency> AnalyzeForDependencies(ClassModel classModel);
    }
}
