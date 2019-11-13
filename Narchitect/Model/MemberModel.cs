using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narchitect.Model
{
    public class MemberModel : ModelBase
    {
        public bool IsPublic { get; set; }

        public bool IsInternal { get; set; }

        public bool IsPrivate { get; set; }

        public bool IsProtected { get; set; }

        public IEnumerable<string> TypeNames { get; set; }

        public char GetAccessSymbol()
        {
            if (IsPublic) return '+';
            if (IsPrivate) return '-';
            if (IsInternal) return '~';
            if (IsProtected) return '#';
            return '?';
        }
    }
}
