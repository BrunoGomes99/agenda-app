using AgendaApp.Domain.Entities;
using AgendaApp.Repository.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Repository.Context
{
    public class MyDbContext : DbContext
    {
        public IConfiguration _configuration { get; }

        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<AlertType> AlertTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var databaseName = _configuration["MySqlConnection:DatabaseName"];

            modelBuilder.HasDefaultSchema(databaseName);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlertTypeConfig).Assembly);

            //outra opção
            //new AcessoConfig().Configure(modelBuilder.Entity<Acesso>());
        }
    }
}
