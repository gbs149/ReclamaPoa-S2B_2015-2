using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReclamaPoa2013.Models
{
    public class Bairro
    {
        public int BairroId { set; get; }
        public String Nome { get; set; }

        public List<Reclamacao> Reclamacoes { get; set; }
    }
}