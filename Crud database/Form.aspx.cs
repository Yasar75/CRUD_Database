using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crud_database
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}