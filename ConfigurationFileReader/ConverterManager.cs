using System.Collections.Generic;
using System.IO;

namespace ConfigurationFileReader
{
    public class ConverterManager
    {
        private readonly IConverterToNodeModel _dataConverter;

        public ConverterManager(IConverterToNodeModel dataConverter)
        {
            _dataConverter = dataConverter;
        }

        public IEnumerable<TreeNode> ConvertFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            return _dataConverter.Convert(fileContent);
        }
    }
}
