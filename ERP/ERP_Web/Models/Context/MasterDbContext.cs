using ERP.Models.DataTemplates.Master;
using ERP_Web.Models.DataTemplates.Master;
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
            if (Environment.UserName == "Riju")
                this.Database.Connection.ConnectionString = @"Data Source=RIJU-PC;initial catalog=ERP;Integrated Security=True;Connect Timeout=30";
            else {
                this.Database.Connection.ConnectionString = @"Data Source=(LocalDB)\v11.0;initial catalog=ERP;Integrated Security=True;Connect Timeout=30";
            }
        }

        public DbSet<user> users { get; set; }
        public DbSet<group> groups { get; set; }
        public DbSet<master_menu> master_menu { get; set; }
    }
}