using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TreeDBContext : DbContext, ITreeDbContext
    {
        public TreeDBContext(DbContextOptions<TreeDBContext> options) : base(options) { }
        public DbSet<Node> Nodes { get; set; }

    }
}
