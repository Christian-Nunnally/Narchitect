using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Narchitect.SyntaxTreeParsing
{
    public class IdentifierNameSyntaxParser : ISyntaxParsingStrategy
    {
        public IList<string> FoundTypeNames { get; } = new List<string>();

        public Type ParsableSyntaxType => typeof(IdentifierNameSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var typeNode = (IdentifierNameSyntax)syntaxNode;
            if (!(typeNode.Parent is QualifiedNameSyntax))
            {
                FoundTypeNames.Add(typeNode.ToString());
            }
        }
    }
}
