using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                //var ator = new Ator { PrimeiroNome = "Tom", UltimoNome = "Hanks" };

                //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now; // Atualiza valores de campos shadow

                //contexto.Atores.Add(ator);

                //contexto.SaveChanges();



                //var ator = contexto.Atores.First();

                //Console.WriteLine(ator);
                //Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue);

                //var atores = contexto.Atores
                //    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update")) // Ordenar descrescente pela coluna Shadow Property
                //    .Take(10);

                //foreach (var ator in atores)
                //{
                //    Console.WriteLine(ator + " - " + contexto.Entry(ator).Property("last_update").CurrentValue);
                //}


                //foreach (var item in contexto.Elenco)
                //{
                //    var entidade = contexto.Entry(item); // Carregando shadow property

                //    var filmId = entidade.Property("film_id").CurrentValue;
                //    var actorId = entidade.Property("actor_id").CurrentValue;
                //    var lastUpd = entidade.Property("last_update").CurrentValue;

                //    Console.WriteLine($"Filme {filmId}, Ator {actorId}, LastUpdate: {lastUpd}");
                //}


                //var filme = contexto.Filmes
                //    .Include(f => f.Atores) // join com tabela de relacionamento N:N film_actor
                //    .ThenInclude(fa => fa.Ator)
                //    .First();

                //Console.WriteLine(filme);
                //Console.WriteLine("Elenco");

                //foreach (var ator in filme.Atores)
                //{
                //    Console.WriteLine(ator.Ator);
                //}



                //var idiomas = contexto.Idiomas
                //    .Include(i => i.FilmesFalados);

                //foreach (var idioma in idiomas)
                //{
                //    Console.WriteLine(idioma);

                //    foreach (var filme in idioma.FilmesFalados)
                //    {
                //        Console.WriteLine(filme);
                //    }

                //    Console.WriteLine("\n");
                //}



                //var ator1 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //var ator2 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
                //contexto.Atores.AddRange(ator1, ator2);
                //contexto.SaveChanges();

                //var emmaWatson = contexto.Atores
                //    .Where(a => a.PrimeiroNome == "Emma" && a.UltimoNome == "Watson");
                //Console.WriteLine($"Total de atores encontrados: {emmaWatson.Count()}.");



                //var idioma = new Idioma { Nome = "English" };

                //var filme = new Filme();
                //filme.Titulo = "Cassino Royala";
                //filme.Duracao = 120;
                //filme.AnoLancamento = "2000";
                //filme.Classificacao = ClassificacaoIndicativa.MaioresQue14;
                //filme.IdiomaFalado = contexto.Idiomas.First();

                //contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                //contexto.Filmes.Add(filme);
                //contexto.SaveChanges();

                //var filmeInserido = contexto.Filmes.First(f => f.Titulo == "Cassino Royala");

                //Console.WriteLine(filmeInserido.Classificacao);



                //foreach (var cliente in contexto.Clientes)
                //{
                //    Console.WriteLine(cliente);
                //}

                //foreach (var funcionario in contexto.Funcionarios)
                //{
                //    Console.WriteLine(funcionario);
                //}



                //var sql = @"select a.*
                //    from actor a
                //      inner join
                //        (select top 5 a.actor_id, count(*) as total
                //        from actor a
                //          inner join film_actor fa on fa.actor_id = a.actor_id
                //        group by a.actor_id
                //        order by total desc) filmes on filmes.actor_id = a.actor_id";

                //var atoresMaisAtuantes = contexto.Atores
                //    .FromSql(sql)
                //    .Include(a => a.Filmografia);

                //// Limitacoes FromSql
                //// Uma query executada pelo FromSql() não pode conter dados/entidades relacionados.
                //// Queries SQL so podem ser utilizadas para retornar tipos que sao entidades, ou seja, tipos que estao sendo gerenciados pelo EF.
                //// As colunas que sao listadas no SELECT devem possuir o mesmo nome que o nome das propriedades da entidade.
                //// O SQL deve retornar TODAS as colunas que sao mapeadas em propriedades para a classe.

                //foreach (var ator in atoresMaisAtuantes)
                //{
                //    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                //}



                // chamando views
                //var sql = @"select a.*
                //    from actor a
                //      inner join
                //         top5_most_starred_actors filmes on filmes.actor_id = a.actor_id";

                //var atoresMaisAtuantes = contexto.Atores
                //    .FromSql(sql)
                //    .Include(a => a.Filmografia);                

                //foreach (var ator in atoresMaisAtuantes)
                //{
                //    Console.WriteLine($"O ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                //}



                //// chamando storeProcedure
                //var categ = "Action";

                //var paramCateg = new SqlParameter("category_name", categ);
                //var paramTotal = new SqlParameter
                //{
                //    ParameterName = "@total_actors",
                //    Size = 4,
                //    Direction = System.Data.ParameterDirection.Output
                //};

                //contexto
                //    .Database
                //    .ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT", 
                //    paramCateg, 
                //    paramTotal);

                //Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}. ");



                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                System.Console.WriteLine($"O total de registros afetados é {registros}.");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                System.Console.WriteLine($"O total de registros afetados é {registros}.");


            }

        }
    }
}