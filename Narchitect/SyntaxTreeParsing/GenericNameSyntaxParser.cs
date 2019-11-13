using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Narchitect.SyntaxTreeParsing
{
    public class GenericNameSyntaxParser : ISyntaxParsingStrategy
    {
        public IList<string> FoundTypeNames { get; } = new List<string>();

        public Type ParsableSyntaxType => typeof(GenericNameSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var typeNode = (GenericNameSyntax)syntaxNode;
            FoundTypeNames.Add(typeNode.Identifier.Text);
        }
    }
}
