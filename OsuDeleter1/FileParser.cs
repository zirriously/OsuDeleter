using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDeleter1
{
    public class FileParser
    {
        private List<string> _foundFilesList = new List<string>();

        public void ParseFiles(string dir, string extension)
        {
            _foundFilesList.AddRange(Directory.GetFiles(dir, extension, SearchOption.AllDirectories));
        }
        
    }
}
