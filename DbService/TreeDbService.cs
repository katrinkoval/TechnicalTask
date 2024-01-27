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

        public List<TreeNode> GetTree()
        {
            List<TreeNode> tree = new List<TreeNode>();

            List<Node> dbNodes = _context.Nodes.ToList();

            IEnumerable<Node> dbRoots = dbNodes.Where(node => node.ParentId == null);

            foreach (Node dbRoot in dbRoots)
            {
                TreeNode root = new TreeNode(dbRoot.Name);
                tree.Add(root);
                AddChildToParentNode(dbRoot, root, dbNodes);
            }

            return tree;
        }

        private void AddChildToParentNode(Node dbParent, TreeNode parent, List<Node> dbNodes)
        {
            IEnumerable<Node> childNodes = dbNodes.Where(n => n.ParentId == dbParent.Id);

            foreach (Node childNode in childNodes)
            {
                TreeNode child = new TreeNode(childNode.Name);
                parent.Children.Add(child);

                AddChildToParentNode(childNode, child, dbNodes);
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
