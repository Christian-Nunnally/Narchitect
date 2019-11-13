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

        public void Parse(SyntaxNode syntaxNode)
        {
            var fieldSyntaxNode = (FieldDeclarationSyntax)syntaxNode;
            var modifiers = fieldSyntaxNode.Modifiers;
            
            var field = new FieldModel();
            field.IsPublic = modifiers.Any(SyntaxKind.PublicKeyword);
            field.IsPrivate = modifiers.Any(SyntaxKind.PrivateKeyword);
            field.IsInternal = modifiers.Any(SyntaxKind.InternalKeyword);
            field.IsProtected = modifiers.Any(SyntaxKind.ProtectedKeyword);
            field.TypeNames = fieldSyntaxNode.Declaration.Type.ParseTypeNamesFromType();
            field.TypeString = fieldSyntaxNode.Declaration.Type.ToString();
            field.Name = fieldSyntaxNode.Declaration.Variables.First().Identifier.Text;
            ParsedFields.Add(field);
        }
    }
}
