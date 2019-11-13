using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Narchitect.Model;

namespace Narchitect.SyntaxTreeParsing
{
    class MethodSyntaxParser : ISyntaxParsingStrategy
    {
        public List<MethodModel> ParsedMethods { get; } = new List<MethodModel>();

        public Type ParsableSyntaxType => typeof(MethodDeclarationSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var methodSyntaxNode = (MethodDeclarationSyntax)syntaxNode;
            var modifiers = methodSyntaxNode.Modifiers;

            var method = new MethodModel();
            method.IsPublic = modifiers.Any(SyntaxKind.PublicKeyword);
            method.IsPrivate = modifiers.Any(SyntaxKind.PrivateKeyword);
            method.IsInternal = modifiers.Any(SyntaxKind.InternalKeyword);
            method.IsProtected = modifiers.Any(SyntaxKind.ProtectedKeyword);
            method.TypeNames = methodSyntaxNode.ReturnType.ParseTypeNamesFromType();
            method.TypeString = methodSyntaxNode.ReturnType.ToString();
            method.Name = methodSyntaxNode.Identifier.Text;
            method.ParameterTypeNames = methodSyntaxNode.ParameterList.Parameters.SelectMany(p => p.Type.ParseTypeNamesFromType());
            ParsedMethods.Add(method);
        }
    }
}
