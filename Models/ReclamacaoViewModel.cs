using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReclamaPoa2013.Models
{
    public class ReclamacaoViewModel
    {
        public int ReclamacaoId { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public String Endereco { get; set; }
        public String Situacao { get; set; }
        public String Bairro { get; set; }
        public String Categoria { get; set; }
        public String UrlImagem { get; set; }
        public String Usuario { get; set; }
    }
}