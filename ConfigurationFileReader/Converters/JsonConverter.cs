using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ConfigurationFileReader
{
    public class JsonConverter: IConverterToNodeModel
    {
        public IEnumerable<TreeNode> Convert(string fileContent)
        {
            return JsonSerializer.Deserialize<List<TreeNode>>(fileContent);
        }

    }
}
