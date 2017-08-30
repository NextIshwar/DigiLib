using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            if (rdolibrary.Checked == true)
            {
                if (Page.IsValid)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["libDB"].ConnectionString);
                    string pass = String.Format("Select Password, aid from tblAdmin where Name='{0}'", txtName.Text);
                    SqlDataAdapter da = new SqlDataAdapter(pass, con);
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblAdmin");
                    string password = (ds.Tables["tblAdmin"].Rows[0]["Password"].ToString()).Trim();
                    Response.Write(txtPass.Text);
                    Response.Write(password);
                    Response.Write(string.Compare(password, txtPass.Text));
                    if(string.Compare(password, txtPass.ToString().Trim()) == -1)
                    {
                        Session["adminId"] = (ds.Tables["tblAdmin"].Rows[0]["aid"]).ToString();
                         Server.Transfer("WebForm3.aspx");
                       ;
                    }
                    else
                    {
                        Response.Redirect("http://www.facebook.com");
                    }
                }
            }
        }

    }
}