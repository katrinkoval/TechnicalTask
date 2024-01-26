using ConfigurationFileReader;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbService
{
    public class TreeDbService: ITreeDbService
    {
        private readonly ITreeDbContext _context;

        public TreeDbService(ITreeDbContext dBContext) 
        { 
            _context = dBContext;
        }
      
        public void FillDbTree(IEnumerable<TreeNode> roots)
        {
            foreach (TreeNode root in roots)
            {
                if (root == null)
                {
                    continue;
                }

                AddNode(root, null);

            }
            _context.SaveChanges();
        }

        private void AddNode(TreeNode node, int? parentId)
        {
            Node newNode = new Node()
            {
                Name = node.Name,
                ParentId = parentId
            };

            _context.Nodes.Add(newNode);

            if (node.Children != null)
            {
                parentId = _context.Nodes
                        .Where(n => n.Name == node.Name)
                        .Select(n => n.Id)
                        .FirstOrDefault();

                foreach (var childNode in node.Children)
                {
                    AddNode(childNode, parentId);
                }
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
