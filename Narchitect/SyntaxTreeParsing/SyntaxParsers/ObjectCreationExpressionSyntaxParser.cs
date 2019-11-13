using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Narchitect.SyntaxTreeParsing
{
    public class ObjectCreationExpressionSyntaxParser : ISyntaxParsingStrategy
    {
        public IList<string> FoundInstantiatedTypeNames { get; } = new List<string>();

        public Type ParsableSyntaxType => typeof(ObjectCreationExpressionSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var newNode = (ObjectCreationExpressionSyntax)syntaxNode;
            var instantiatedTypeNames = newNode.Type.ParseTypeNamesFromType();
            foreach (var instantiatedTypeName in instantiatedTypeNames)
            {
                if (!FoundInstantiatedTypeNames.Contains(instantiatedTypeName))
                {
                    FoundInstantiatedTypeNames.Add(instantiatedTypeName);
                }
            }
        }
    }
}
