using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Project
{
    public partial class RegisterP1 : System.Web.UI.Page
    {
        internal bool Phone_Check(string p)
        {
            if (string.IsNullOrEmpty(p) == false)
            {
                int parse;
                bool result = int.TryParse(p, out parse);

                if (p.Length == 11 & result == true)
                {
                    if (p.StartsWith("015") || p.StartsWith("016") || p.StartsWith("017") || p.StartsWith("018") || p.StartsWith("019"))
                    {
                        lp.Text = "Valid Phone Number";
                        return true;
                    }
                    else
                    {
                        lp.Text = "Invalid Phone Number";
                        return false;
                    }
                }
                else
                {
                    lp.Text = "Invalid Phone Number";
                    return false;
                }
            }

            else
            {
                lp.Text = "Empty Phone Number";
                return false;
            }
        }

        internal bool Email_Check(string e)
        {
            if (string.IsNullOrEmpty(e) == false)
            {
                if (e.EndsWith("@gmail.com") || e.EndsWith("@yahoo.com") || e.EndsWith("@hot.com"))
                {
                    le.Text = "Valid Email Address";
                    return true;
                }
                else
                {
                    le.Text = "Invalid Email Address";
                    return false;
                }
            }
            else
            {
                le.Text = "Empty Email Address";
                return false;
            }
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string phone = Regp1_phone.Text;
            string email = Regp1_phone.Text;
            
                Phone_Check(phone);
                Email_Check(email);

        }

        protected void Regp1_next_Click(object sender, EventArgs e)
        {
            string phone = Request["Regp1_phone"];
            string email = Request["Regp1_email"];

            if (Phone_Check(phone) & Email_Check(email))
            {
                Session["phone"] = phone;
                Session["email"] = email;
                Response.Redirect("RegisterP2.aspx");
            }
        }

        protected void Regp1_check_Click(object sender, EventArgs e)
        {
            string phone = Request["Regp1_phone"];
            string email = Request["Regp1_email"];

            Phone_Check(phone);
            Email_Check(email);
        }
    }
}