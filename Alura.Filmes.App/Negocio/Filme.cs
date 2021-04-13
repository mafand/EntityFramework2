using Alura.Filmes.App.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public short Duracao { get; set; } // A convencao para descoberta de colunas procura por propriedades publicas com ambos getter e setter
        public string TextoClassificacao { get; private set; } // coluna mapeada na tabela
        public ClassificacaoIndicativa Classificacao 
        {
            get { return TextoClassificacao.ParaValor(); }
            set { TextoClassificacao = value.ParaString(); }
        }
        public IList<FilmeAtor> Atores { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }

        public Filme()
        {
            Atores = new List<FilmeAtor>();
        }


        public override string ToString()
        {
            return $"Filme ({Id}): {Titulo} - {AnoLancamento}";
        }
    }
}
