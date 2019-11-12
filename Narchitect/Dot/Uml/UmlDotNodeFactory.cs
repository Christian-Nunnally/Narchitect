using Narchitect.Model;
using System.Collections.Generic;
using System.Text;

namespace Narchitect.Dot.Uml
{
    public class UmlDotNodeFactory
    {
        public DotNode CreateFromClass(ClassModel classNode)
        {
            var umlNode = new DotNode(classNode.Name);
            var umlNodeLabel = CreateLabel(classNode);

            umlNode.StyleProperties["label"] = umlNodeLabel;
            return umlNode;
        }

        private string CreateLabel(ClassModel classNode)
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.Append(classNode.Name);
            builder.Append("|");
            CreateFieldLabels(classNode.Fields, builder);
            builder.Append("|");
            CreatePropertyLabels(classNode.Properties, builder);
            builder.Append("|");
            CreateMethodLabels(classNode.Methods, builder);
            builder.Append("}");
            return builder.ToString();
        }

        private void CreateFieldLabels(IList<FieldModel> fields, StringBuilder builder)
        {
            foreach (var field in fields)
            {
                builder.Append(CreateFieldLabel(field));
                builder.Append("\\l");
            }
        }

        private void CreatePropertyLabels(IList<PropertyModel> properties, StringBuilder builder)
        {
            foreach (var property in properties)
            {
                builder.Append(CreatePropertyLabel(property));
                builder.Append("\\l");
            }
        }

        private void CreateMethodLabels(IList<MethodModel> methods, StringBuilder builder)
        {
            foreach (var method in methods)
            {
                builder.Append(CreateMethodLabel(method));
                builder.Append("\\l");
            }
        }

        private string CreateFieldLabel(FieldModel field)
        {
            return $"{field.GetAccessSymbol()} {field.Name} : {field.TypeName}";
        }

        private string CreatePropertyLabel(PropertyModel field)
        {
            return $"{field.GetAccessSymbol()} {field.Name} : {field.TypeName}";
        }

        private string CreateMethodLabel(MethodModel method)
        {
            // TODO: handle collections and generic types so we don't need to do this.
            var cleanTypeName = method.TypeName.Contains("<")
                ? method.TypeName.Substring(0, method.TypeName.IndexOf('<'))
                : method.TypeName;

            var parameters = string.Join(", ", method.ParameterTypeNames);
            return $"{method.GetAccessSymbol()} {method.Name}({parameters}) : {cleanTypeName}";
        }
    }
}
