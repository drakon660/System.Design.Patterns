using System.IO;
using System.Design.Patterns.Functional;

namespace System.Design.Patterns.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //string value = string.Empty;
            //using (var fs = File.OpenText("E:\\grils_names.txt"))
            //{
            //    value = fs.ReadToEnd();
            //}

            var value = Disposable.Using<StreamReader, string>(() => File.OpenText("E:\\grils_names.txt"), reader => reader.ReadToEnd()).Split(',');
        }
    }
}
