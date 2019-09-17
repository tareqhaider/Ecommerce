using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;


namespace Login_Project
{
    public partial class Admin : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();

                if (Session["pid"] == null)
                {
                    Session["pid"] = 0;
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

                string user = Session["user"].ToString();

                string pass = Session["pass"].ToString();

                string type = Session["type"].ToString();

                if (!string.IsNullOrEmpty(user) & !string.IsNullOrEmpty(pass) & !string.IsNullOrEmpty(type))
                {
                    int temp_uc = da.UsernameCheck(user);
                    int temp_pc = da.PasswordCheck(user, pass);
                    string temp_typ = da.Retrive_User_Type(user, pass);

                    if (temp_uc == 1 & temp_pc == 1 & string.Compare(temp_typ,"admin") == 0)
                    {
                        msg.Text = "Welcome" + " " + user;

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }

                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            bool flag = Check_Entries(Tname.Text,Tprice.Text,Tquantity.Text,DropDownList1.Text,Tdescription.Text);

            if (string.Compare(DropDownList2.Text, "Insert") == 0 & flag)
            {
                int i = da.Insert_Product(Tname.Text, Tdescription.Text, float.Parse(Tprice.Text), Convert.ToInt16(Tquantity.Text),DropDownList1.Text);

                if (i == 1)
                {
                    msg.Text = "Record successfully inserted";
                }
                else
                {
                    msg.Text = "Failed";
                }

                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();
            }

            else if (string.Compare(DropDownList2.Text, "Update") == 0 & flag & Convert.ToInt16(Session["pid"]) > 0)
            {
                int i = da.Update_Product(Convert.ToInt16(Session["pid"]), Tname.Text, Tdescription.Text, float.Parse(Tprice.Text), Convert.ToInt16(Tquantity.Text), DropDownList1.Text);

                if (i == 1)
                {
                    msg.Text = "Record successfully updated";
                }
                else
                {
                    msg.Text = "Failed";
                }

                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();
            }

            else if (string.Compare(DropDownList2.Text, "Delete") == 0 & flag)
            {
                int i = da.Delete_Product(Convert.ToInt16(Session["pid"]));

                if (i == 1)
                {
                    msg.Text = "Record successfully deleted";
                }
                else
                {
                    msg.Text = "Failed";
                }

                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();
            }

            else
            {
                msg.Text = "Fill all the details";
               
            }
        }

        private bool Check_Entries(string name,string price,string quantity,string category,string detail)
        {
            float f = 0;
            int i = 0;
            bool bname = !string.IsNullOrEmpty(name);
            bool bprice = float.TryParse(price, out f);
            bool bquantity= int.TryParse(quantity, out i);
            bool cat = !string.IsNullOrEmpty(category);
            bool des = !string.IsNullOrEmpty(detail);

            if (bname & bprice & bquantity & cat & des)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

     

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = da.Search_By_Key(TextBox1.Text, "product");

            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[dt.Rows.Count - 1];
                Session["pid"] = Convert.ToInt16(dr["id"]);
                Tname.Text = dr["name"].ToString();
                Tprice.Text = dr["price"].ToString();
                Tquantity.Text = dr["quantity"].ToString();
                DropDownList1.Text = dr["category"].ToString();
                Tdescription.Text = dr["detail"].ToString();
            }

            else
            {
                Tname.Text = string.Empty;
                Tprice.Text = string.Empty;
                Tquantity.Text = string.Empty;
                DropDownList1.Text = string.Empty;
                Tdescription.Text = string.Empty;
            }

            GridView1.DataSource = da.Search_By_Key(TextBox1.Text, "product");
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}