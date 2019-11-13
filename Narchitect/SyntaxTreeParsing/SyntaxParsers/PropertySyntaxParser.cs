using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Narchitect.Model;

namespace Narchitect.SyntaxTreeParsing
{
    class PropertySyntaxParser : ISyntaxParsingStrategy
    {
        public List<PropertyModel> ParsedProperties { get; } = new List<PropertyModel>();

        public Type ParsableSyntaxType => typeof(PropertyDeclarationSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var propertySyntaxNode = (PropertyDeclarationSyntax)syntaxNode;
            var modifiers = propertySyntaxNode.Modifiers;
            
            var property = new PropertyModel();
            property.IsPublic = modifiers.Any(SyntaxKind.PublicKeyword);
            property.IsPrivate = modifiers.Any(SyntaxKind.PrivateKeyword);
            property.IsInternal = modifiers.Any(SyntaxKind.InternalKeyword);
            property.IsProtected = modifiers.Any(SyntaxKind.ProtectedKeyword);
            property.TypeNames = propertySyntaxNode.Type.ParseTypeNamesFromType();
            property.TypeString = propertySyntaxNode.Type.ToString().Split('.').Last();
            property.Name = propertySyntaxNode.Identifier.Text;
            ParsedProperties.Add(property);
        }
    }
}
