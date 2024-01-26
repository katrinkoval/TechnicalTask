using System.Collections.Generic;
using System.IO;

namespace ConfigurationFileReader
{
    public class ReaderManager
    {
        private readonly IConverterToNodeModel _dataConverter;

        public ReaderManager(IConverterToNodeModel dataConverter)
        {
            _dataConverter = dataConverter;
        }

        public IEnumerable<TreeNode> ReadFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            return _dataConverter.Convert(fileContent);
        }
    }
}
