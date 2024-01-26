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
        public IEnumerable<NodeModel> Convert(string fileContent)
        {
        // logic of converting string to Nodes

        //keyA:keyB:keyC:value1
        //keyA: keyB: keyD: value2
        //keyE:value3
        //keyC:keyD: value4
        //keyA:keyD: value5

            return null;
        }
    }
}
