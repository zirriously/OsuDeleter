using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDeleter1
{
    public static class FileParser
    {
        public static void ParseFiles(string dir, string extension)
        {
            Form1.FileList.AddRange(Directory.GetFiles(dir, extension, SearchOption.AllDirectories)); //unused
        }
        
    }
}
