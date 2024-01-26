using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileReader
{
    internal interface IFileReader
    {
        IEnumerable<NodeModel> Read(string fileContent);
    }
}
