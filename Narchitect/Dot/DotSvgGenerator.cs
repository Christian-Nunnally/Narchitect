using System.Diagnostics;

namespace Narchitect.Dot
{
    internal class DotSvgGenerator
    {
        public DotSvgGenerator()
        {

        }

        public void GenerateSVGFromDot(string dotFilePath, string svgFilePath)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C dot.exe -Tsvg {dotFilePath} -o {svgFilePath}";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit(5000);
        }
    }
}
