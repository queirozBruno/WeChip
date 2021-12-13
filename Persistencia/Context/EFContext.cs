using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo.Tabelas;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

namespace Persistencia.Context
{
    public class EFContext:DbContext //Extende de DBContext
    {
        public EFContext() : base("WeChip_DB") //Passando o nome da minha connectionString, definida no web.Config, para a classe base DBContext
        {
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, ContextMigrationConfiguration>(true));
        }

        //Aqui estou dizendo que determinada classe é uma tabela do banco de dados.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Status> Status { get; set; }

        //resolve o problema da pluralização das tabelas
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    internal sealed class ContextMigrationConfiguration : DbMigrationsConfiguration<EFContext>
    {
        public ContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}
