using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinTodo.SQLite.Models;

namespace XamarinTodo.SQLite.Contexts
{
    public class LocalDbContext : DbContext
    {
        private static Action<DbContextOptionsBuilder> _onConfigure;

        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            _onConfigure?.Invoke(optionsBuilder);
        }

        public DbSet<TodoDataModel> Todos { get; set; }
    }
}
