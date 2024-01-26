using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileReader
{
    public class NodeModel
    {
        public string Key {  get; set; }
        public List<NodeModel> Value { get; set; }
    }
}
