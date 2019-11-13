using Microsoft.CodeAnalysis;
using System;

namespace Narchitect
{
    public interface ISyntaxParsingStrategy
    {
        Type ParsableSyntaxType { get; }

        void Parse(SyntaxNode syntaxNode);
    }
}
