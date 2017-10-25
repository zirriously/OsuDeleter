using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuDeleter1
{
    public static class FileDeleter
    {
        public static void DeleteFiles(List<string> pathList)
        {
            try
            {
                foreach (var path in pathList)
                    File.Delete(Convert.ToString(path));
            }
            catch (Exception)
            {
                MessageBox.Show("Access denied. Try running as administrator");
                throw;
            }
        }
    }
}
