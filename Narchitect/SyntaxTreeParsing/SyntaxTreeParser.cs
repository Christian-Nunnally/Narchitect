using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace Narchitect
{
    public class SyntaxTreeParser
    {
        private IDictionary<Type, ISyntaxParsingStrategy> _syntaxParsingStrategies = new Dictionary<Type, ISyntaxParsingStrategy>();

        public void Parse(SyntaxNode node)
        {
            var nodeType = node.GetType();
            if (_syntaxParsingStrategies.TryGetValue(nodeType, out ISyntaxParsingStrategy strategy))
            {
                strategy.Parse(node);
            }
            foreach (var child in node.ChildNodes())
            {
                Parse(child);
            }
        }

        public void RegisterParsingStratagy(ISyntaxParsingStrategy strategy)
        {
            _syntaxParsingStrategies[strategy.ParsableSyntaxType] = strategy;
        }
    }
}
