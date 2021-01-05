using Crud.DataAccess.Extensions;
using Crud.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Crud.DataAccess
{
    public class CrudContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        public CrudContext()
        {

        }
        public CrudContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb = mb.SetDataType();
            mb = mb.MapConfiguration();
            base.OnModelCreating(mb);
        }
    }
}
