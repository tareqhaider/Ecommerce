using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Project
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["count"] == null)
                {
                    Application["count"] = 0;
                }

                if (Application["con"] == null)
                {
                    Application["con"] = 0;
                }

                if (Session["count"] == null)
                {
                    Session["count"] = 0;
                }

                if (Session["user"] == null)
                {
                    Session["user"] = string.Empty;
                }

                if (Session["pass"] == null)
                {
                    Session["pass"] = string.Empty;
                }
            }


            string user = Session["user"].ToString();

            string pass = Session["pass"].ToString();

            if (!string.IsNullOrEmpty(user) & !string.IsNullOrEmpty(pass) & DateTime.Compare(DateTime.Now, Convert.ToDateTime(Session["Disable"])) >= 0)
            {
                DataAccess dta = new DataAccess();


                int temp_uc = dta.UsernameCheck(user);
                int temp_pc = dta.PasswordCheck(user, pass);


                if (temp_uc == 1 & temp_pc == 1)
                {
                    Label1.Text = "this is home";

                    int con = (int)Application["con"];

                    ++con;

                    Application["con"] = con;

                }

            }

            else
            {
                Response.Redirect("Login.aspx");
            }

            

            int counta = (int)Application["count"];

            ++counta;

            Application["count"] = counta;



            TC.Text = "Total Count is:" + Application["count"].ToString();
            LC.Text = "Logged Count is:" + Application["con"].ToString();

        }
    }
    
}