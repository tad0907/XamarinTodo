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
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
        }

        public string DbDirectory { get; set; }

        public DbSet<TodoDataModel> Todos { get; set; }
    }
}
