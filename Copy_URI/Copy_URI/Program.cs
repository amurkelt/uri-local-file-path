using System;
using System.Windows.Forms;
using System.IO;

namespace AbsoluteUriGenerator
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                var executableName = typeof(Program).Assembly.GetName().Name + ".exe";
                Console.WriteLine("Usage: {0} pathToConvert", executableName);
                Console.WriteLine("Example: {0} \"C:\\foo\"", executableName);
                return 1;
            }

            var path = args[0];
            Console.WriteLine("Resolving file:// URI of path: {0}", path);
            var uri = new Uri(path).AbsoluteUri;
            var name = Path.GetFileName(path);

            Console.WriteLine("Setting clipboard to resolved file:// URI: {0}", uri);
            Clipboard.SetText("[" + name + "](" + uri + ")");
            return 0;
        }
    }
}