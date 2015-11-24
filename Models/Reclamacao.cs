using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReclamaPoa2013.Models
{
    public enum Situacao { Aberta, Encerrada, Resolvida }

    public class Reclamacao
    {
        public int ReclamacaoId { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public String Endereco { get; set; }
        public Situacao Situacao { get; set; }
        public String UrlImagem { get; set; }
        public String Usuario { get; set; }

        public Bairro Bairro { get; set; }
        public Categoria Categoria { get; set; }
        public List<Comentario> Comentarios { get; set; }


        public override string ToString()
        {
            return String.Format("{0}: ({1}) {2} {3} {4} {5} {6} {7} {8}",
                                 ReclamacaoId,
                                 Categoria.Nome,
                                 Titulo,
                                 Descricao,
                                 Data,
                                 Endereco,
                                 Situacao,
                                 Bairro.Nome,
                                 Usuario);
        }
    }
}