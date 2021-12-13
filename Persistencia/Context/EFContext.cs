using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo.Tabelas;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Collections.Generic;
using System.Linq;

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

        protected override void Seed(Persistencia.Context.EFContext context)
        {
            if (context.Clientes.Any() || context.Status.Any())
            {
                return; //Se o BD já foi populado não vai executar o código restante do método
            }

            Status s1 = new Status(1, "Nome Livre", "Não", "Não", "0001");
            Status s2 = new Status(2, "Não deseja ser contatado", "Sim", "Não", "0007");
            Status s3 = new Status(3, "Cliente aceitou a oferta", "Sim", "Sim", "0009");
            Status s4 = new Status(4, "Caiu a ligação", "Não", "Não", "0015");
            Status s5 = new Status(5, "Viajou", "Não", "Não", "0019");
            Status s6 = new Status(6, "Falecido", "Sim", "Não", "0021");

            Cliente c1 = new Cliente(1, "Bruno dos Santos Queiroz", "12096614627", 1000.00, "35998581388", s1);

            Produto p1 = new Produto(1, "Mouse", 20.00, "HARDWARE", "00015");
            Produto p2 = new Produto(2, "Teclado", 30.00, "HARDWARE", "00106");
            Produto p3 = new Produto(3, "Monitor 17'", 350.00, "HARDWARE", "00200");
            Produto p4 = new Produto(4, "Pen Drive 8 GB", 30.00, "HARDWARE", "00211");
            Produto p5 = new Produto(5, "Pen Drive 16 GB", 50.00, "HARDWARE", "00314");
            Produto p6 = new Produto(6, "AVAST", 199.99, "HARDWARE", "00459");
            Produto p7 = new Produto(7, "Pacote Office", 499.00, "HARDWARE", "01104");
            Produto p8 = new Produto(8, "Spotify (3 meses)", 45.50, "HARDWARE", "01108");
            Produto p9 = new Produto(9, "Netflix (1 mês)", 19.90, "HARDWARE", "01107");

            List<Status> listStatus = new List<Status> { s1, s2, s3, s4, s5, s6 };
            List<Produto> listProduto = new List<Produto> { p1, p2, p3, p4, p5, p6, p7, p8, p9 };

            //AddRange permite adicionar vários objetos de uma só vez para fazer a inclusão no BD
            context.Status.AddRange(listStatus);
            context.Clientes.Add(c1);
            context.Produtos.AddRange(listProduto);

            context.SaveChanges(); //Confirma as alterações no banco de dados
        }
    }
}
