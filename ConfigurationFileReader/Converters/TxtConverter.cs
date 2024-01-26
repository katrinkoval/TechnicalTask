using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationFileReader.FileReaders
{
    internal class TxtConverter:IConverterToNodeModel
    {
        public IEnumerable<TreeNode> Convert(string fileContent)
        {
            // converting string to NodesModel

            return null;
        }
    }
}
