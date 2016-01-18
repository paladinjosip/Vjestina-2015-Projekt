using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JJTube.Models
{
    public class JJTubeDbContext: DbContext
    {
    public DbSet<People> People { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<Item> Items { get; set; }
    }
            
}