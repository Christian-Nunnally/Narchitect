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

        public void Parse(SyntaxTreeParser parser, SyntaxNode syntaxNode)
        {
            var methodSyntaxNode = (MethodDeclarationSyntax)syntaxNode;
            var modifiers = methodSyntaxNode.Modifiers;
            var typeName = methodSyntaxNode.ReturnType.ToString();
            var fieldName = methodSyntaxNode.Identifier.Text;
            var parameterTypeNames = methodSyntaxNode.ParameterList.Parameters.Select(p => p.Type.ToString());

            var method = new MethodModel();
            method.IsPublic = modifiers.Any(SyntaxKind.PublicKeyword);
            method.IsPrivate = modifiers.Any(SyntaxKind.PrivateKeyword);
            method.IsInternal = modifiers.Any(SyntaxKind.InternalKeyword);
            method.IsProtected = modifiers.Any(SyntaxKind.ProtectedKeyword);
            method.TypeName = typeName;
            method.Name = fieldName;
            method.ParameterTypeNames = parameterTypeNames;
            ParsedMethods.Add(method);
        }
    }
}
