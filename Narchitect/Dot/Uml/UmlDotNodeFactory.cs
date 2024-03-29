﻿using Narchitect.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Narchitect.Dot.Uml
{
    public class UmlDotNodeFactory
    {
        public DotNode CreateFromClass(ClassModel classNode)
        {
            var umlNode = new DotNode(classNode.Name);
            var umlNodeLabel = CreateUmlFormattedLabel(classNode);

            umlNode.StyleProperties["label"] = umlNodeLabel;
            umlNode.StyleProperties["shape"] = "none";
            umlNode.StyleProperties["height"] = "0";
            umlNode.StyleProperties["width"] = "0";
            umlNode.StyleProperties["margin"] = "0";
            return umlNode;
        }

        private string CreateUmlFormattedLabel(ClassModel classNode)
        {
            var nodeTitleLines = new string[] { $"<b>{classNode.Name}</b>" };
            var fieldLines = classNode.Fields.Select(CreateMemberLabel).ToList();
            var propertyLines = classNode.Properties.Select(CreateMemberLabel).ToList();
            var methodLines = classNode.Methods.Select(CreateMethodLabel).ToList();

            var nodeTitleTable = BuildHtmlTableString(nodeTitleLines, "center", cellPadding: 6, borderThickness: 1);
            var nodeFieldTable = BuildHtmlTableString(fieldLines, "left", cellPadding: 2, borderThickness: 1);
            var nodePropertyTable = BuildHtmlTableString(propertyLines, "left", cellPadding: 2, borderThickness: 1);
            var nodeMethodTable = BuildHtmlTableString(methodLines, "left", cellPadding: 2, borderThickness: 1);
            var tables = new string[] { nodeTitleTable, nodeFieldTable, nodePropertyTable, nodeMethodTable };

            var nodeLines = tables.Where(x => !string.IsNullOrEmpty(x)).ToList();
            return BuildHtmlTableString(nodeLines, "left", cellPadding: 0, borderThickness: 0, addPaddingToTop: false);
        }

        private string BuildHtmlTableString(IList<string> contents, string contentAlignment, int cellPadding, int borderThickness, bool addPaddingToTop = true)
        {
            if (!contents.Any()) return string.Empty;
            var builder = new StringBuilder();
            builder.Append($"<table border=\"{borderThickness}\" cellspacing=\"0\">");
            if (addPaddingToTop) builder.Append($"<tr><td border=\"0\" height=\"3\"></td></tr>");
            foreach (var content in contents)
            {
                builder.Append($"<tr><td border=\"0\" cellpadding=\"{cellPadding}\" align=\"{contentAlignment}\" valign=\"middle\">");
                builder.Append(content);
                builder.Append($"</td></tr>");
            }
            builder.Append("</table>");
            return builder.ToString();
        }

        private string CreateMemberLabel(MemberModel member)
        {
            return $"{member.GetAccessSymbol()} {member.Name} : {ReplaceHtmlSpecialCharacters(member.TypeString)}";
        }

        private string CreateMethodLabel(MethodModel method)
        {
            var parameters = string.Join(", ", method.ParameterTypeNames.Select(n => ReplaceHtmlSpecialCharacters(n)));
            return $"{method.GetAccessSymbol()} {method.Name}({parameters}) : {ReplaceHtmlSpecialCharacters(method.TypeString)}";
        }

        private string ReplaceHtmlSpecialCharacters(string text)
        {
            return text.Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}
