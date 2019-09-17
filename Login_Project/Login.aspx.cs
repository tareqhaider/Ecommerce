using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Login_Project
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Disable"] == null)
                {
                    Session["Disable"] = DateTime.Now.AddMinutes(-1);
                }

                if (Session["PlogCount"] == null)
                {
                    Session["PlogCount"] = 0;
                }

                if (Session["UlogCount"] == null)
                {
                    Session["UlogCount"] = 0;
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

                if (Session["type"] == null)
                {
                    Session["type"] = string.Empty;
                }

            }
           

            if (DateTime.Compare(DateTime.Now,Convert.ToDateTime(Session["Disable"])) <= 0)
                {
                    Login_login.Enabled = false;
                    
                    Login_forgot.Visible = false;
                }
            
            
            else if (Request["Login_register"] != null)
            {
                Response.Redirect("RegisterP1.aspx");
            }
            else if (Request["Login_forgot"] != null)
            {
                Response.Redirect("ResetPass.aspx");
            }

        }

        protected void Login_login_Click(object sender, EventArgs e)
        {
            string user = Login_username.Text;
            string pass = Login_password.Text;

            user = user.Replace(" ", String.Empty);
            pass = pass.Replace(" ", String.Empty);

            Session["user"] = user;
            Session["pass"] = pass;


            //if (Login_remember.Checked == true)
            //{
            //    DataAccess dta = new DataAccess();



            //    Response.Cookies["user"].Value = user;
            //    Response.Cookies["pwd"].Value = pass;



            //    Response.Cookies["user"].Expires = DateTime.Now.AddDays(365);
            //    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(365);

            //    int temp_pc = dta.PasswordCheck(user, pass);


            //    if (temp_pc == 1)
            //    {
            //        Response.Redirect("Home.aspx");

            //    }
            //}

            //else

            //{

            //    Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);

            //    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);

            //}

            if (!string.IsNullOrEmpty(user) & !string.IsNullOrEmpty(pass) & DateTime.Compare(DateTime.Now, Convert.ToDateTime(Session["Disable"])) >= 0)
            {
                DataAccess dta = new DataAccess();


                int temp_uc = dta.UsernameCheck(user);
                int temp_pc = dta.PasswordCheck(user, pass);
                Session["type"] = dta.Retrive_User_Type(user,pass);


                if (temp_uc == 1 & temp_pc == 1 & string.Compare(Session["type"].ToString(),"admin") ==0)
                {
                    
                    Response.Redirect("Admin.aspx");
                    
                }

                else if (temp_uc == 1 & temp_pc == 1 & string.Compare(Session["type"].ToString(), "user") == 0)
                {

                    Response.Redirect("User.aspx");

                }

                else if (temp_uc == 0)
                {
                    Session["UlogCount"] = (int)Session["UlogCount"] + 1;
                    if ((int)Session["UlogCount"] >= 3)
                    {
                        Session["Disable"] = DateTime.MaxValue;
                        Login_login.Enabled = false;
                        Login_forgot.Visible = false;
                    }
                }

                else if (temp_pc == 0)
                {
                    Session["PlogCount"] = (int)Session["PlogCount"] + 1;
                     

                    if ((int)Session["PlogCount"] == 3)
                    {
                        Session["Disable"] = DateTime.Now.AddMinutes(5);
                        msg.Text = "10";

                    }

                    else if ((int)Session["PlogCount"] == 6)
                    {
                        Session["Disable"] = DateTime.Now.AddMinutes(15);
                        msg.Text = "30";
                    }
                    else if((int)Session["PlogCount"] >= 9)
                    {
                        Session["Disable"] = DateTime.MaxValue;
                        msg.Text = "P";
                    }
                }
                else
                {
                    Login_login.Enabled = false;

                    Login_forgot.Visible = false;
                }
               
            }
        }

        
    }
}
