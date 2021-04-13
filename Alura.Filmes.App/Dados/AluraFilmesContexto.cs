using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; } // Por padrao/convencao o nome da tabela e determinado pelo nome da propriedade DbSet
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }        
        public DbSet<Idioma> Idiomas { get; set; }
        // Pessoa - Classe base da hieraquia Cliente e Funcionario
        // - Padroes que o Entity utiliza para mapeamento de heranças
        // TPC - Table per Concrete Class - Entity cria uma tabela para cada tipo concreto na hierarquia de tipos.
        // TPH - Table per Hierarchy - Cria uma unica tabela para armazenar os registros de toda a hierarquia de tipos. Para isso, precisara adicionar uma coluna para definir o tipo daquele registro.
        // TPT - Table per Type - Entity cria uma tabela para cada tipo participante da hierarquia de tipos.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AluraFilmes;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());

            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        }
    }
}
