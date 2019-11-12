using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narchitect.Dot
{
    public class DotEdge : DotElement
    {
        public DotEdge(string from, string to) : base($"{from} -> {to}")
        {
        }
    }
}
