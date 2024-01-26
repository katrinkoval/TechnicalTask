using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationFileReader
{
    public class JsonConverter: IFileReader
    {
        public IEnumerable<NodeModel> Read(string fileContent)
        {
            return JsonSerializer.Deserialize<List<NodeModel>>(fileContent);
        }

    }
}
