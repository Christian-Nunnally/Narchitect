using System;
using System.Collections.Generic;
using System.Linq;
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
            string typeName = typeNode.ToString().Split('.').Last();
            FoundTypeNames.Add(typeName);
        }
    }
}
