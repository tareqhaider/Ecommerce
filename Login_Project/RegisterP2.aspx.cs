using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Routing;

namespace Login_Project
{
    public partial class RegisterP2 : System.Web.UI.Page
    {
        internal bool Username_Check(string u)
        {
            if (string.IsNullOrEmpty(u) == false)
            {
                u = u.Replace(" ", String.Empty);
                lu.Text = "Your Username is:" + u;
                return true;
            }
            else
            {
                lu.Text = "Empty Username";
                return false;
            }

        }

        internal bool Password_Check(string p)
        {
            if (string.IsNullOrEmpty(p) == false)
            {
                p = p.Replace(" ", String.Empty);
                lp.Text = "Your Password is:" + p;
                return true;
            }
            else
            {
                lp.Text = "Empty Password";
                return false;
            }

        }

        internal bool Answer_Check(string a)
        {
            if (string.IsNullOrEmpty(a) == false)
            {
                return true;
            }
            else
            {
                la.Text = "Empty Answer";
                return false;
            }

        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["phone"] == null)
                {
                    Session["phone"] = string.Empty;
                }

                if (Session["email"] == null)
                {
                    Session["email"] = string.Empty;
                }
            }

            if (string.IsNullOrEmpty(Session["phone"].ToString()) | string.IsNullOrEmpty(Session["email"].ToString()))
            {
                Response.Redirect("RegisterP1.aspx");
                
            }

            lu.Text = "Please Do not use Spaces";
            lp.Text = "Please Do not use Spaces";
        }

        protected void Regp2_confirm_Click(object sender, EventArgs e)
        {
            string username = Request["Regp2_username"].ToString();
            string password = Request["Regp2_password"].ToString();
            string answer = Request["Regp2_answer"].ToString();
            string phone = Session["phone"].ToString();
            string email = Session["email"].ToString();

            username = username.Replace(" ", String.Empty);
            password = password.Replace(" ", String.Empty);

            if (Username_Check(username) & Password_Check(password) & Answer_Check(answer))
            {

                

                int ls = 0;
                int tc = 0;
                string question = Regp2_question.Text;

                DataAccess da = new DataAccess();

                int temp = da.InsertUserInfo(username, password, email, phone, question, answer, ls, tc);

                if (temp > 0)
                {
                    msg.Text = "Record Saved";
                }

            }
        }
    }
}