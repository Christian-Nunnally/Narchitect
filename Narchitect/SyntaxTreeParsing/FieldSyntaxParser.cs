using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Narchitect.Model;

namespace Narchitect.SyntaxTreeParsing
{
    class FieldSyntaxParser : ISyntaxParsingStrategy
    {
        public List<FieldModel> ParsedFields { get; } = new List<FieldModel>();

        public Type ParsableSyntaxType => typeof(FieldDeclarationSyntax);

        public void Parse(SyntaxTreeParser parser, SyntaxNode syntaxNode)
        {
            var fieldSyntaxNode = (FieldDeclarationSyntax)syntaxNode;
            var modifiers = fieldSyntaxNode.Modifiers;
            var typeName = fieldSyntaxNode.Declaration.Type.ToString();
            var fieldName = fieldSyntaxNode.Declaration.Variables.First().Identifier.Text;

            var field = new FieldModel();
            field.IsPublic = modifiers.Any(SyntaxKind.PublicKeyword);
            field.IsPrivate = modifiers.Any(SyntaxKind.PrivateKeyword);
            field.IsInternal = modifiers.Any(SyntaxKind.InternalKeyword);
            field.IsProtected = modifiers.Any(SyntaxKind.ProtectedKeyword);
            field.TypeName = typeName;
            field.Name = fieldName;
            ParsedFields.Add(field);
        }
    }
}
