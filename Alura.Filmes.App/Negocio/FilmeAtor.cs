using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    public class FilmeAtor // Classe de ligacao para o relacionamento N:N
    {
        public Filme Filme { get; set; }
        public Ator Ator { get; set; }
    }
}
