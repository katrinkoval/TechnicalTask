using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigurationFileReader.FileReaders
{
    public class TxtConverter:IConverterToNodeModel
    {
        public IEnumerable<TreeNode> Convert(string fileContent)
        {
            List<TreeNode> tree = new List<TreeNode>();

            string[] branches = fileContent.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string branch in branches)
            {
                string[] nodes = branch.Split(':');

                bool containsNode = tree.Any(node => node.Name == nodes[0]); //check if parent node is already added to tree

                if (!containsNode)
                {
                    TreeNode parent = new TreeNode(nodes[0]);
                    tree.Add(parent);
                }

                // add children
                for (int i = 1; i < nodes.Length; i++)
                {
                    TreeNode parent = tree.Find(node => node.Name == nodes[i - 1]);

                    TreeNode child = tree.Find(node => node.Name == nodes[i]);  

                    if (child == null)
                    {
                        child = new TreeNode(nodes[i]);
                        tree.Add(child);
                    }

                    bool containsChild = parent.Children.Any(node => node.Name == nodes[i]); //check if parent contains this child

                    if (!containsChild)
                    {
                        parent.Children.Add(child);
                    }
                }
            }

            return tree;
        }
    }
}
