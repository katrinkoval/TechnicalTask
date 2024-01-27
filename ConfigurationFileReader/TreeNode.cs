using System;
using System.Collections.Generic;

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
