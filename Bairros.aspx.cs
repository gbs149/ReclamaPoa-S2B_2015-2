using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Bairros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            GridView1.DataSource = _db.Bairros.ToList();
            GridView1.DataBind();
        }
    }
}