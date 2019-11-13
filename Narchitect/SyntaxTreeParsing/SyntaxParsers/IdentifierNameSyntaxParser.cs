using System;
using System.Collections.Generic;
using System.Linq;
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
            var typeNode = syntaxNode;
            while (typeNode.Parent is QualifiedNameSyntax)
            {
                typeNode = typeNode.Parent;
            }
            FoundTypeNames.Add(typeNode.ToString().Split('.').Last());
        }
    }
}
