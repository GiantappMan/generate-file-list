using System.Drawing;
using System.Reflection;
using Console = Colorful.Console;

namespace GenerateFileList
{
    internal class Program
    {
        private static string _runDir = string.Empty;
        private static string _workDir = string.Empty;
        static void Main(string[] args)
        {
            _workDir = Environment.CurrentDirectory;
            _runDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            Console.WriteLine($"Working Directory:{_workDir}", Color.Gray);
            Console.WriteLine($"Running Directory:{_runDir}", Color.Gray);

            var files = Directory.EnumerateFiles(_workDir, "*.*", new EnumerationOptions()
            {
                RecurseSubdirectories = true
            });

            //写入text
            string destPath = Path.Combine(_workDir, "list.txt");
            var writer = new StreamWriter(destPath);
            int count = 0;
            foreach (var file in files)
            {
                count++;
                writer.WriteLine(file.Substring(_workDir.Length + 1));
            }
            writer.Flush();

            Console.WriteLine($"{destPath}", Color.Green);
            Console.WriteLine($"created, found {count} files.");
        }
    }
}