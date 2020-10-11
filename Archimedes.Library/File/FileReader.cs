using System;
using System.IO;
using System.Reflection;

namespace Archimedes.Library.File
{
    public class FileReader
    {
        public string Reader(string fileName)
        {
            try
            {
                var resource = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream($"Specials.Oxi.MessageTypes.{fileName}.json");

                if (resource==null)
                {
                    Console.WriteLine($"Unable to find resource. Error: {fileName}");
                    return string.Empty;
                }

                using (var reader = new StreamReader(resource))
                {
                    var result = reader.ReadToEnd();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to read resource {fileName}");
            }
        }
    }
}