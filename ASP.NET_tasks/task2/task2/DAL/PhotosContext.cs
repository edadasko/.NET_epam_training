using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using task2.Models;

namespace task2.DAL
{
    public class PhotosContext : DbContext
    {
        public PhotosContext() : base("DefaultConnection")
        { }

        public DbSet<Photo> Photos { get; set; }
    }
}