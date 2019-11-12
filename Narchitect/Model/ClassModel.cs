using System.Collections.Generic;

namespace Narchitect.Model
{
    public class ClassModel : ModelBase
    {
        public List<FieldModel> Fields { get; internal set; }
        public List<PropertyModel> Properties { get; internal set; }
        public IEnumerable<string> BaseTypeNames { get; internal set; }
        internal List<MethodModel> Methods { get; set; }
    }
}
