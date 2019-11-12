using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace Narchitect
{
    internal interface ISyntaxParsingStrategy
    {
        Type ParsableSyntaxType { get; }

        void Parse(SyntaxTreeParser parser, SyntaxNode syntaxNode);
    }
}
