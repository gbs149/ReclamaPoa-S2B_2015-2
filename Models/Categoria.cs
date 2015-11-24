using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReclamaPoa2013.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<Reclamacao> Reclamacoes { get; set; }
    }
}