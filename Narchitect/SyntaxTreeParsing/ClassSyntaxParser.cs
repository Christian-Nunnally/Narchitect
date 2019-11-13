using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Narchitect.Model;

namespace Narchitect.SyntaxTreeParsing
{
    internal class ClassSyntaxParser : ISyntaxParsingStrategy
    {
        public IList<ClassModel> ParsedClasses { get; } = new List<ClassModel>();

        public Type ParsableSyntaxType => typeof(ClassDeclarationSyntax);

        public void Parse(SyntaxNode syntaxNode)
        {
            var classSyntaxNode = (ClassDeclarationSyntax)syntaxNode;

            var fieldParser = new FieldSyntaxParser();
            var propertyParser = new PropertySyntaxParser();
            var methodParser = new MethodSyntaxParser();
            var internalParser = new SyntaxTreeParser();
            internalParser.RegisterParsingStratagy(fieldParser);
            internalParser.RegisterParsingStratagy(propertyParser);
            internalParser.RegisterParsingStratagy(methodParser);
            internalParser.Parse(classSyntaxNode);

            var className = classSyntaxNode.Identifier.Text;
            var baseTypeNames = classSyntaxNode.BaseList?.Types.Select(t => t.Type.ToString());

            var classNode = new ClassModel();
            classNode.Name = className;
            classNode.Fields = fieldParser.ParsedFields;
            classNode.Properties = propertyParser.ParsedProperties;
            classNode.Methods = methodParser.ParsedMethods;
            classNode.BaseTypeNames = baseTypeNames;

            ParsedClasses.Add(classNode);
        }
    }
}
