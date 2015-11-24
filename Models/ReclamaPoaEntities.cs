using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ReclamaPoa2013.Models
{
    public class ReclamaPoaEntities : DbContext
    {
        public ReclamaPoaEntities()
            : base("ReclamaPoaConnection")
        { }
        public DbSet<Reclamacao> Reclamacoes { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}