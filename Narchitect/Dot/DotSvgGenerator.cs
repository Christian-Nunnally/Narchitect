using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narchitect.Dot
{
    internal class DotSvgGenerator
    {
        public DotSvgGenerator()
        {

        }

        public void GenerateSVGFromDot(string dotFilePath, string svgFilePath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C dot.exe -Tsvg {dotFilePath} -o {svgFilePath}";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
