using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileReader
{
    internal class ReaderManager
    {
        private IFileReader _fileReader;

        public ReaderManager(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<NodeModel> ReadFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            return _fileReader.Read(fileContent);
        }
    }
}
