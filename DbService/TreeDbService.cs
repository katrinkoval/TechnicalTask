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
      
        public void FillDbTree(IEnumerable<NodeModel> roots)
        {
            foreach (NodeModel root in roots)
            {
                if (root == null)
                {
                    continue;
                }

                AddNode(root, null);

            }
            _context.SaveChanges();
        }

        private void AddNode(NodeModel node, int? parentId)
        {
            Node newNode = new Node()
            {
                Name = node.Key,
                ParentId = parentId
            };

            _context.Nodes.Add(newNode);

            if (node.Value != null)
            {
                parentId = _context.Nodes
                        .Where(n => n.Name == node.Key)
                        .Select(n => n.Id)
                        .FirstOrDefault();

                foreach (var childNode in node.Value)
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
