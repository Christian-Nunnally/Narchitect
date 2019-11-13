using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Narchitect.SyntaxTreeParsing
{
    public class PredefinedTypeSyntaxParser : ISyntaxParsingStrategy
    {
        public IList<string> FoundTypeNames { get; } = new List<string>();

        public Type ParsableSyntaxType => typeof(PredefinedTypeSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var typeNode = (PredefinedTypeSyntax)syntaxNode;
            FoundTypeNames.Add(typeNode.ToString());
        }
    }
}
