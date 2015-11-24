using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReclamaPoa2013.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public String Texto { get; set; }

        public Reclamacao Reclamacao { get; set; }
    }
}