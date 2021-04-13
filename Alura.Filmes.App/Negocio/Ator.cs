using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    //[Table("actor")]
    public class Ator
    {
        //[Column("actor_id")]
        public int Id { get; set; } // Por convencao a propriedade com o nome Id ou NomeDaClasseId sera usada como chave primaria

        //[Required]
        //[Column("first_name", TypeName = "varchar(45)")]
        public string PrimeiroNome { get; set; }

        //[Required]
        //[Column("last_name", TypeName = "varchar(45)")]
        public string UltimoNome { get; set; }

        public IList<FilmeAtor> Filmografia { get; set; }

        public Ator()
        {
            Filmografia = new List<FilmeAtor>();
        }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
