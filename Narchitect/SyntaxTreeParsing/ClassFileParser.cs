using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;

namespace Narchitect
{
    internal static class ClassFileParser
    {
        public static CompilationUnitSyntax Parse(string classFilePath)
        {
            if (!File.Exists(classFilePath))
            {
                throw new FileNotFoundException($"Unable to find class file {classFilePath}");
            }

            var classFileText = File.ReadAllText(classFilePath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(classFileText);
            return (CompilationUnitSyntax)tree.GetRoot();
        }
    }
}
