using System.Collections.Generic;
using System.IO;

namespace ConfigurationFileReader
{
    public class ReaderManager
    {
        private readonly IConverterToNodeModel _fileReader;

        public ReaderManager(IConverterToNodeModel fileReader)
        {
            _fileReader = fileReader;
        }

        public IEnumerable<NodeModel> ReadFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            return _fileReader.Convert(fileContent);
        }
    }
}
