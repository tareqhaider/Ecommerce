using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Login_Project
{
    public partial class ResetPass : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            FormsVisibility(false);
            
        }

        protected void CFM_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();


            string username = TU.Text;
            username = username.Replace(" ", string.Empty);

            string answer = "";

            if (ViewState["noc"] == null)
            {
                ViewState["noc"] = 0;
            }

            
                int noc = (int)ViewState["noc"];
                ++noc;
                ViewState["noc"] = noc;
            



            switch (Convert.ToInt16(ViewState["noc"]))
            {

                case 0:
                    FormsVisibility(false);
                    FieldClear();

                    break;


                case 1:
                    if (!string.IsNullOrEmpty(username))
                    {
                        username = username.Replace(" ", string.Empty);

                        string q = da.Retrive_User_Question(username);

                        LQ.Text = q;

                        if (!string.IsNullOrEmpty(q))
                        {
                            CFM.Text = "Check";

                        }
                        else
                        {
                            ViewState["noc"] = 0;
                        }
                    }
                    else
                    {
                        ViewState["noc"] = 0;
                    }

                    break;

                case 2:
                    answer = TA.Text;
                    if (!string.IsNullOrEmpty(answer))
                    {
                        string a = da.Retrive_User_Answer(username);

                        int temp = string.Compare(a, answer);

                        if (temp == 0)
                        {
                            FormsVisibility(true);
                            CFM.Text = "Proceed";
                        }
                        else
                        {
                            ViewState["noc"] = 1;
                        }
                    }
                    else
                    {
                        ViewState["noc"] = 1;
                    }

                    break;

                case 3:
                    string np = TNP.Text;
                    string cp = TCP.Text;

                    np = np.Replace(" ", string.Empty);
                    cp = cp.Replace(" ", string.Empty);

                    int comp = string.Compare(np, cp);
                    FormsVisibility(true);

                    if (comp == 0 & !string.IsNullOrEmpty(np) & !string.IsNullOrEmpty(cp))
                    {
                        Label1.Text = "Your Password is:" + cp;

                        int temp = da.InsertPassword(username, cp);

                        if (temp == 1)
                        {
                            
                            msg.Text = "Passwords Changed";
                        }
                        else
                        {
                            ViewState["noc"] = 2;
                        }


                    }

                    else
                    {
                        ViewState["noc"] = 2;
                    }

                    break;

                default:

                    ViewState["noc"] = 0;
                    FormsVisibility(false);
                    FieldClear();

                    break;

            }

            msg.Text = ViewState["noc"].ToString();

            
        }

        public void FormsVisibility(bool b)
        {
            LNP.Visible = b;
            LCP.Visible = b;

            Label1.Visible = b;

            TNP.Visible = b;
            TCP.Visible = b;

            TNP.Enabled = b;
            TCP.Enabled = b;
        }

        public void FieldClear()
        {
            TU.Text = string.Empty;
            LQ.Text = string.Empty;
            TA.Text = string.Empty;
            TNP.Text = string.Empty;
            TCP.Text = string.Empty;
        }
    }
}