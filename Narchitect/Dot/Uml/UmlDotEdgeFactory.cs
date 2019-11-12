﻿namespace Narchitect.Dot.Uml
{
    public class UmlDotEdgeFactory
    {
        public DotEdge CreateUmlDotEdge(UmlEdgeType edgeType, string from, string to, string label = "")
        {
            switch (edgeType)
            {
                case UmlEdgeType.Inheritence:
                case UmlEdgeType.Generalization:
                    return CreateGeneralizationEdge(from, to, label);
                case UmlEdgeType.Association:
                case UmlEdgeType.OneWayAsssociation:
                    return CreateAssociationEdge(from, to, label);
                case UmlEdgeType.Dependency:
                    return CreateDependencyEdge(from, to, label);
                case UmlEdgeType.Composition:
                default:
                    return CreateGeneralizationEdge(from, to, label);
            }
        }

        private DotEdge CreateGeneralizationEdge(string from, string to, string label)
        {
            var edge = new DotEdge(from, to);
            edge.StyleProperties["style"] = "dashed";
            edge.StyleProperties["arrowhead"] = "empty";
            return edge;
        }

        private DotEdge CreateAssociationEdge(string from, string to, string label)
        {
            return new DotEdge(from, to);
        }

        private DotEdge CreateDependencyEdge(string from, string to, string label)
        {
            var edge = new DotEdge(from, to);
            edge.StyleProperties["style"] = "dotted";
            edge.StyleProperties["arrowhead"] = "vee";
            return edge;
        }
    }
}