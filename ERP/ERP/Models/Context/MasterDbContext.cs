using ERP.Models.DataTemplates.Master;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERP.Models.Context
{
    public class MasterDbContext:DbContext
    {
        public MasterDbContext()
        {
            this.Database.Connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\RONIT\Documents\ERP.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public DbSet<user> users { get; set; }
        public DbSet<group> groups { get; set; }
    }
}