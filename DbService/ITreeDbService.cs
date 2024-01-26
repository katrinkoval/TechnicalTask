using ConfigurationFileReader;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;

namespace DbService
{
    public interface ITreeDbService: IDisposable
    {
        void FillDbTree(IEnumerable<NodeModel> roots);

    }
}
