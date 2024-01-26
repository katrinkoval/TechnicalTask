using System.Collections.Generic;

namespace ConfigurationFileReader
{
    public interface IConverterToNodeModel
    {
        IEnumerable<NodeModel> Convert(string fileContent);
    }
}
