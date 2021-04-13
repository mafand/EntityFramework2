using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alura.Filmes.App.Migrations
{
    public partial class FilmeCheckConstraint : Migration
    {
        // Entity não dá suporte nativo a restrições do tipo CHECK 
        // Por isso vamos utilizar comandos sql personalizados na criacao de uma migration para criar a restricao CHECK
        // 1 - Criar uma migracao vazia ou seja quando nao ha alteracoes no mapeamento de classes. Add-Migration nome_da_migracao
        // 2 - Adicionar o comando sql personalizado nos metodos Up e Down da migration

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"ALTER TABLE[dbo].[film]
                ADD CONSTRAINT[check_rating] CHECK (
                [rating] = 'NC-17' OR
                [rating] = 'R' OR
                [rating] = 'PG-13' OR
                [rating] = 'PG' OR
                [rating] = 'G')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE[dbo].[film] DROP CONSTRAINT[check_rating]");
        }
    }
}
