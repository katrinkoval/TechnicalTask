using ConfigurationFileReader;
using System;
using System.Collections.Generic;

namespace DbService
{
    public interface ITreeDbService: IDisposable
    {
        void FillDbTree(IEnumerable<TreeNode> roots);

        List<TreeNode> GetTree();
    }
}
