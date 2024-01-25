using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TreeDBContext: DbContext
    {
        private DbSet<Node> Nodes { get; set; }

        public TreeDBContext(DbContextOptions<TreeDBContext> options) : base(options) { }
    }
}
