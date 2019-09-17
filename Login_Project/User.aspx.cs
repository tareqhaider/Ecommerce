using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Login_Project
{
    public partial class User : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();

                GridView2.DataSource = da.Get_Table("cart");
                GridView2.DataBind();

                TextBox1.Text = "0";

                if (Session["pid"] == null)
                {
                    Session["pid"] = 0;
                }
                //if (Session["ses"] == null)
                //{
                //    Random generator = new Random();
                //    String r = generator.Next(0, 999999).ToString("D6");
                //    Session["ses"] = Convert.ToInt16(r);
                //}
                if (ViewState["count"] == null)
                {
                    ViewState["count"] = 0;
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

                //if (!string.IsNullOrEmpty(user) & !string.IsNullOrEmpty(pass) & !string.IsNullOrEmpty(type))
                //{
                //    int temp_uc = da.UsernameCheck(user);
                //    int temp_pc = da.PasswordCheck(user, pass);
                //    string temp_typ = da.Retrive_User_Type(user, pass);

                //    if (temp_uc == 1 & temp_pc == 1 & string.Compare(temp_typ, "user") == 0)
                //    {
                //        msg.Text = "Welcome" + " " + user;

                //    }
                //    else
                //    {
                //        Response.Redirect("Login.aspx");
                //    }

                //}

                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = da.Search_By_Key(TextBox2.Text, "product");

            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[dt.Rows.Count - 1];
                Session["pid"] = Convert.ToInt16(dr["id"]);
                
            }
            else
            {
                msg.Text = "Please select a specific product";
            }
            

            GridView1.DataSource = da.Search_By_Key(TextBox2.Text, "product");
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int s = (int)ViewState["count"];
            s = s + 1;

            ViewState["count"] = s;

            TextBox1.Text = ViewState["count"].ToString();
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(TextBox1.Text) > 0)
            {
                DataTable dt = da.Search_By_Key(Session["pid"].ToString(), "product");
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[dt.Rows.Count - 1];
                    string name = dr["name"].ToString();
                    string p = dr["price"].ToString();
                    float f = float.Parse(p);
                    float t = Convert.ToInt16(TextBox1.Text) * f;
                    int id = Convert.ToInt16(Session["pid"]);

                    int i = da.Insert_Cart(id,name, Convert.ToInt16(TextBox1.Text),t);

                    if (i == 1)
                    {
                        msg.Text = "Record successfully inserted";
                    }
                    else
                    {
                        msg.Text = "Failed";
                    }

                }
                GridView1.DataSource = da.Get_Table("product");
                GridView1.DataBind();

                GridView2.DataSource = da.Get_Table("cart");
                GridView2.DataBind();

            }
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            DataTable dt = da.Get_Table("cart");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int id = Convert.ToInt16(dr["pid"]);
                string name = dr["name"].ToString();
                int quantity = Convert.ToInt16(dr["quantity"]);
                float total = float.Parse(dr["total"].ToString());
                msg.Text = id.ToString();
                int mid = da.get_uid(Session["user"].ToString(),Session["pass"].ToString());

                int qty = da.Select_Product_quantity(id);
                qty = qty - quantity;

                int edr = da.Update_Product_quantity(id,qty);

                int  g = da.Insert_Order(id,mid,qty,total,name, Session["user"].ToString());
                if (g > 0 & edr > 0)
                {
                    msg.Text = "Order Complete";
                }
                else
                {
                    msg.Text = "Failed";
                }
                

            }
            da.Delete_Cart_Items();
            GridView2.DataSource = da.Get_Table("cart");
            GridView2.DataBind();
            GridView1.DataSource = da.Get_Table("product");
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            da.Delete_Cart_Items();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}