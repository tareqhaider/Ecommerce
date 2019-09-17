using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace Login_Project
{
    internal class DataAccess
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Login_Project\LP.MDF;Integrated Security=True;Connect Timeout=30");

        public string SendMessage(string s)
        {
            string msg = s;
            return msg;
        }
        public int UsernameCheck(string u)
        {
            int temp_uc = 0;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                string uc = string.Format("SELECT COUNT(*) FROM Member WHERE Username ='" + u + "'");
                SqlCommand cmd_uc = new SqlCommand(uc, con);
                temp_uc = Convert.ToInt32(cmd_uc.ExecuteScalar().ToString());
                

                con.Close();
            }
            
            catch(Exception X)
            {
                SendMessage(X.Message.ToString());
            }
            return temp_uc;
        }

        public int PasswordCheck(string u, string p)
        {
            int temp_pc = 0;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pc = string.Format("SELECT COUNT(*) FROM Member WHERE Username ='" + u + "' AND Password ='" + p + "'");
                SqlCommand cmd_pc = new SqlCommand(pc, con);
                temp_pc = Convert.ToInt32(cmd_pc.ExecuteScalar().ToString());
                

                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }
            return temp_pc;

        }

        public int InsertUserInfo(string u, string p, string e, string m, string q, string a, int l, int c)
        {
            int temp = 0;
            try
            {



                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\TAREQ666\DOCUMENTS\LP.MDF;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string query = string.Format("INSERT INTO Member(username, password, email, phone, question, answer, log_status, try_count) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", u, p, e, m, q, a, l, c);

                SqlCommand cmd = new SqlCommand(query, con);

                temp = cmd.ExecuteNonQuery();


                con.Close();
            }

            catch (Exception Ex)
            {
                SendMessage(Ex.Message);
            }
            return temp;
        }

        public string Retrive_User_Question(string u)
        {
            string q = "";

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pc = string.Format("SELECT question FROM Member WHERE Username ='" + u + "'");
                SqlCommand cmd_pc = new SqlCommand(pc, con);
                q = cmd_pc.ExecuteScalar().ToString();
                

                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }

            return q;
        }

        public string Retrive_User_Type(string u,string p)
        {
            string q = "";

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pc = string.Format("SELECT type FROM Member WHERE Username ='" + u + "' AND Password ='" + p + "'");
                SqlCommand cmd_pc = new SqlCommand(pc, con);
                q = cmd_pc.ExecuteScalar().ToString();


                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }

            return q;
        }

        public string Retrive_User_Answer(string u)
        {
            string q = "";

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pc = string.Format("SELECT answer FROM Member WHERE Username ='" + u + "'");
                SqlCommand cmd_pc = new SqlCommand(pc, con);
                q = cmd_pc.ExecuteScalar().ToString();


                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }

            return q;
        }

        public int InsertPassword(string u,string p)
        {
            int temp = 0;
            try
            {



                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\TAREQ666\DOCUMENTS\LP.MDF;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string query = string.Format("UPDATE Member SET password = '{0}' WHERE username = '{1}'", p, u);

                SqlCommand cmd = new SqlCommand(query, con);

                temp = cmd.ExecuteNonQuery();


                con.Close();
            }

            catch (Exception Ex)
            {
                SendMessage(Ex.Message);
            }
            return temp;
        }

        public DataTable Get_Table(string table)
        {
           
            DataTable dt = new DataTable();
            

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string t = string.Format("SELECT * FROM {0}",table);
                SqlCommand cmd = new SqlCommand(t, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }

            return dt;
        }
        public DataTable Search_By_Key(string key, string table)
        {
            DataTable dt = new DataTable();
            con.Close();

            try
            {
                con.Open();

                int parse;

                bool stat = int.TryParse(key, out parse);

                if (stat == true)
                {
                    string qr = string.Format("SELECT * FROM {0} WHERE {0}.id = {1}", table, int.Parse(key));
                    SqlCommand cmd = new SqlCommand(qr, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                else
                {
                    string qr = string.Format("select * from {0} where {0}.name like '" + key + "%' or {0}.name like '%" + key + "%' or {0}.name like '%" + key + "'", table);
                    SqlCommand cmd = new SqlCommand(qr, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }


                con.Close();

            }

            catch (Exception e)
            {
               string s = e.Message;
            }

            return dt;
        }

        public int Insert_Product(string name, string detail, float price, int quantity, string category)
        {
            con.Close();

            string s = string.Empty;
            int rtn = -1;

            try
            {
                
                con.Open();

                string qr = string.Format("INSERT INTO Product(name,detail,price,quantity,category) VALUES('{0}','{1}', {2} , {3} ,'{4}')", name, detail, price, quantity, category);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception e)
            {
               s = e.Message;
            }

            return rtn;
        }

        public int Update_Product(int id, string name, string detail, float price, int quantity, string category)
        {
            con.Close();

            int rtn = -1;

            try
            {
                
                con.Open();

                string qr = string.Format("UPDATE Product SET name ='{1}',detail ='{2}',price = {3} ,quantity = {4},category ='{5}' WHERE id={0} ", id, name, detail, price, quantity, category);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception e)
            {
                string s = e.Message;
            }

            return rtn;
        }

        public int Delete_Product(int id)
        {

            int i = -1;
            try
            {
                con.Open();

                string qr = string.Format("Delete FROM Product WHERE Product.id = {0}",  id);
                SqlCommand cmd = new SqlCommand(qr, con);
                i = cmd.ExecuteNonQuery();

                con.Close();

            }

            catch (Exception e)
            {
                string s = e.Message;
            }
            return i;
        }

        public int Insert_Cart(int id ,string name, int amount, float total)
        {
            con.Close();

            string s = string.Empty;
            int rtn = -1;

            try
            {

                con.Open();

                string qr = string.Format("INSERT INTO cart(pid,name,quantity,total) VALUES({0},'{1}', {2} , {3})", id, name, amount, total);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception e)
            {
                s = e.Message;
            }

            return rtn;
        }

        public int Insert_Order(int id, int mid, int amount,float total, string name, string mname)
        {
            con.Close();

            string s = string.Empty;
            int rtn = -1;

            try
            {

                con.Open();

                string qr = string.Format("INSERT INTO ord(cid,pid,quantity,total,pname,cname) VALUES({0}, {1} , {2} , {3}, '{4}','{5}')", id, mid, amount, total,name,mname);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception e)
            {
                s = e.Message;
            }

            return rtn;
        }

        public int Delete_Cart_Items()
        {

            int i = -1;
            try
            {
                con.Open();

                string qr = string.Format("Delete FROM cart");
                SqlCommand cmd = new SqlCommand(qr, con);
                i = cmd.ExecuteNonQuery();

                con.Close();

            }

            catch (Exception e)
            {
                string s = e.Message;
            }
            return i;
        }

        public int Update_Product_quantity(int id,int quantity)
        {
            con.Close();

            int rtn = -1;

            try
            {

                con.Open();

                string qr = string.Format("UPDATE Product SET quantity = {1} WHERE id={0} ", id, quantity);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = cmd.ExecuteNonQuery();
                con.Close();

            }

            catch (Exception e)
            {
                string s = e.Message;
            }

            return rtn;
        }

        public int Select_Product_quantity(int id)
        {
            con.Close();

            int rtn = -1;

            try
            {

                con.Open();

                string qr = string.Format("Select quantity from Product WHERE id={0} ", id);
                SqlCommand cmd = new SqlCommand(qr, con);
                rtn = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();

            }

            catch (Exception e)
            {
                string s = e.Message;
            }

            return rtn;
        }

        public int get_uid(string u, string p)
        {
            int q = 0;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string pc = string.Format("SELECT id FROM Member WHERE Username ='" + u + "' AND Password ='" + p + "'");
                SqlCommand cmd_pc = new SqlCommand(pc, con);
                q = Convert.ToInt16(cmd_pc.ExecuteScalar());


                con.Close();
            }

            catch (Exception X)
            {
                SendMessage(X.Message.ToString());
            }

            return q;
        }
    }
}