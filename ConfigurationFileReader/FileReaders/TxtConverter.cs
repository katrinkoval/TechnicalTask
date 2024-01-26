using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationFileReader.FileReaders
{
    internal class TxtConverter:IFileReader
    {
        public IEnumerable<NodeModel> Read(string fileContent)
        {
            // logic of converting string to Nodes

            return null;
        }
    }
}
