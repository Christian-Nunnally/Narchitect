using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narchitect.Dot
{
    public class DotElement : DotObject
    {
        public string Identifier { get; }

        public DotElement(string identifier)
        {
            Identifier = identifier;
        }

        public string GenerateDotString()
        {
            var builder = new StringBuilder();
            BuildDotElementString(builder, Identifier, StyleProperties);
            return builder.ToString();
        }
    }
}
