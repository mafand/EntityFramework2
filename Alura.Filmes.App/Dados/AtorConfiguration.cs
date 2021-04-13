using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            // Separando o codigo orientado a objetos do codigo relacional
            builder
                .ToTable("actor");

            builder
                .Property(a => a.Id)
                .HasColumnName("actor_id");

            builder
                .Property(a => a.PrimeiroNome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(a => a.UltimoNome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property<DateTime>("last_update") // Shadow properties: colunas do banco de dados que nao possuem valor na camada de negocios
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()") // Valor padrao -> getdate() -> funcao sqlserver
                .IsRequired();

            builder
                .HasIndex(a => a.UltimoNome)
                .HasName("idx_actor_last_mame");

            builder
                .HasAlternateKey(a => new { a.PrimeiroNome, a.UltimoNome }); // Restricao Indice Unico (Unique Index)
        }
    }
}
