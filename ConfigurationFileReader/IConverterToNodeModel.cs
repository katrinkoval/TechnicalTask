using System.Collections.Generic;

namespace ConfigurationFileReader
{
    public interface IConverterToNodeModel
    {
        IEnumerable<TreeNode> Convert(string fileContent);
    }
}
