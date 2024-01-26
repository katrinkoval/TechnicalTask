using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DataAccessLayer
{
    public interface ITreeDbContext: IDisposable
    {
        DbSet<Node> Nodes { get; set; }

        int SaveChanges();
    }
}
