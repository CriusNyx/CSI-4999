using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Util
{
    public static class StringExtensions
    {
        public static string Indent(this string source, string indent)
        {
            source = source.Replace("\r\n", "\n");
            source = source.Replace("\n", "\n" + indent);
            source = indent + source;
            return source;
        }
    }
}
