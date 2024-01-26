using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationFileReader
{
    public class TreeNode
    {
        public TreeNode(string name) 
        { 
            Name = name;
            Children = new List<TreeNode>();
        }

        public string Name {  get; set; }
        public List<TreeNode> Children { get; set; }
    }
}
