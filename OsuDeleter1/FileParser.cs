using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDeleter
{
    public class FileParser
    {
        public IEnumerable<string> ParseFiles(string dir, string extension)
        {
            var result = Directory.GetFiles(dir, extension, SearchOption.AllDirectories).ToList();

            return result;
        }

    }
}
