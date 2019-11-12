using System.Collections.Generic;

namespace Narchitect.Model
{
    class MethodModel : MemberModel
    {
        public IEnumerable<string> ParameterTypeNames { get; internal set; }
    }
}
