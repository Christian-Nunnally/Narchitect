using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Narchitect.SyntaxTreeParsing
{
    public static class TypeSyntaxExtensions
    {
        public static IEnumerable<string> ParseTypeNamesFromType(this TypeSyntax typeSyntax)
        {
            var parser = new SyntaxTreeParser();
            var predefinedTypeParser = new PredefinedTypeSyntaxParser();
            var genericNameParser = new GenericNameSyntaxParser();
            var identifierNameParser = new IdentifierNameSyntaxParser();
            parser.RegisterParsingStratagy(predefinedTypeParser);
            parser.RegisterParsingStratagy(genericNameParser);
            parser.RegisterParsingStratagy(identifierNameParser);
            parser.Parse(typeSyntax);
            return predefinedTypeParser.FoundTypeNames
                .Concat(genericNameParser.FoundTypeNames)
                .Concat(identifierNameParser.FoundTypeNames);
        }
    }
}
