using Narchitect.Dot.Uml;
using System.Collections.Generic;

namespace Narchitect.Analysis
{
    public class Dependency : IEqualityComparer<Dependency>
    {
        public Dependency(string fromIdentifier, string toIdentifier, UmlEdgeType edgeType)
        {
            FromIdentifier = fromIdentifier;
            ToIdentifier = toIdentifier;
            EdgeType = edgeType;
        }

        public string FromIdentifier { get; }

        public string ToIdentifier { get; }

        public UmlEdgeType EdgeType { get; }

        public override bool Equals(object obj)
        {
            if (obj is Dependency dependency)
            {
                return dependency.FromIdentifier == FromIdentifier
                    && dependency.ToIdentifier == ToIdentifier
                    && dependency.EdgeType == EdgeType;
            }
            return false;
        }

        public bool Equals(Dependency x, Dependency y)
        {
            return x.FromIdentifier == y.FromIdentifier
                    && x.ToIdentifier == y.ToIdentifier
                    && x.EdgeType == y.EdgeType;
        }

        public override int GetHashCode()
        {
            var hashCode = -1315872783;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FromIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ToIdentifier);
            hashCode = hashCode * -1521134295 + EdgeType.GetHashCode();
            return hashCode;
        }

        public int GetHashCode(Dependency obj)
        {
            return obj.GetHashCode();
        }
    }
}
