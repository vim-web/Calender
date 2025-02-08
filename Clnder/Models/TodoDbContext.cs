using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Npgsql;

namespace Clnder.Models
{

    public class TodoDbContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }

        public TodoDbContext() : base("PostgresConnection") { }

       

        public DbSet<TodoTask> GetTasks()
        {
            return TodoTasks;
        }

        public void SetTasks(DbSet<TodoTask> value)
        {
            TodoTasks = value;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = NpgsqlServices.Instance;
            base.OnModelCreating(modelBuilder);
        }
    }

}