using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample_Telly
{
    
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ary patel\Downloads\New folder (2)\sample_Telly\Telly.mdf"";Integrated Security=True");
        string credit = "credit";
        string debit = "debit";

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabPage2.Show();
            tabPage1.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabPage3.Show();
            tabPage1.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabPage4.Show();
            tabPage1.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabPage5.Show();
            tabPage1.Hide();
        }

        public void account()
        {
            con.Open();
            //
            string query = "SELECT SUM(AMOUNT) FROM ACCOUNT WHERE TYPE = 'debit';";
            SqlCommand de = new SqlCommand(query, con);
            de.ExecuteNonQuery();
            label14.Text = de.ExecuteScalar().ToString();

            //
            string query1 = "SELECT SUM(AMOUNT) FROM ACCOUNT WHERE TYPE = 'credit';";
            SqlCommand cr = new SqlCommand(query1, con);
            cr.ExecuteNonQuery();
            label12.Text = cr.ExecuteScalar().ToString();

            //
            string query2 = "SELECT SUM(AMOUNT) FROM ACCOUNT;";
            SqlCommand all = new SqlCommand(query2, con);
            all.ExecuteNonQuery();
            label9.Text = all.ExecuteScalar().ToString();

            con.Close();
        }

        public void datagrid()
        {
            try
            {
                DataTable dnn = new DataTable();
                DataTable ann = new DataTable();
                DataTable dbtt = new DataTable();
                DataTable crr = new DataTable();
                con.Open();
                SqlDataAdapter an = new SqlDataAdapter("SELECT * FROM ACCOUNT_NAME", con);
                SqlDataAdapter cr = new SqlDataAdapter("SELECT * FROM ACCOUNT WHERE TYPE = 'credit'", con);
                SqlDataAdapter dbt = new SqlDataAdapter("SELECT * FROM ACCOUNT WHERE TYPE = 'debit'", con);
                SqlDataAdapter dn = new SqlDataAdapter("SELECT * FROM ACCOUNT", con);

                con.Close();
                an.Fill(ann);
                cr.Fill(crr);
                dbt.Fill(dbtt);
                dn.Fill(dnn);

                dataGridView1.DataSource = dnn;
                dataGridView2.DataSource = ann;
                dataGridView3.DataSource = crr;
                dataGridView4.DataSource = dbtt;
                dataGridView5.DataSource = dnn;

                an.Update(ann);
                cr.Update(crr);
                dbt.Update(dbtt);
                dn.Update(dnn);
            }
            catch
            {

            }

        }

        private void Home_Load(object sender, EventArgs e)
        {
            // tab's name
            tabPage1.Text = "Home";
            tabPage2.Text = "Add Name";
            tabPage3.Text = "Credit";
            tabPage4.Text = "Deposit";
            tabPage5.Text = "Delete Name";

            // create account table and add item in index 1
            try
            {
                con.Open();

                string query3 = "use [C:\\Users\\Ary patel\\Downloads\\New folder (2)\\sample_Telly\\Telly.mdf] IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ACCOUNT_NAME') BEGIN select * from ACCOUNT_NAME PRINT 'Table exists.' END ELSE BEGIN CREATE TABLE ACCOUNT_NAME(NAME nvarchar(50), DATE datetime); PRINT 'Table does not exist.' INSERT INTO ACCOUNT_NAME(NAME) values(NULL); print 'ok' END";

                string query4 = "use [C:\\Users\\Ary patel\\Downloads\\New folder (2)\\sample_Telly\\Telly.mdf] IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ACCOUNT') BEGIN select * from ACCOUNT PRINT 'Table exists.' END ELSE BEGIN CREATE TABLE ACCOUNT(NAME nvarchar(50), AMOUNT numeric(10,0), REMARK nvarchar(500), TYPE nvarchar(20), DATE datetime); PRINT 'Table does not exist.' INSERT INTO ACCOUNT(NAME, AMOUNT, REMARK, TYPE, DATE) values(NULL, NULL, NULL, NULL, NULL); print 'ok' END";

                SqlCommand db = new SqlCommand(query3, con);
                SqlCommand c = new SqlCommand(query4, con);

                if (db.ExecuteNonQuery() != 0 && c.ExecuteNonQuery() != 0)
                {
                    con.Close();
                }
                else
                {
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error in Creating Database.");
            }
            datagrid();
            account();

            //combobox valueS
            string query = "SELECT * FROM ACCOUNT_NAME";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //ScomboBox1.SelectedIndex['0'] = "";
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "NAME";
            comboBox1.DataSource = dt;


        }

        public void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // add name
                con.Open();
                string query5 = "INSERT INTO ACCOUNT_NAME(NAME, DATE) values(@name, @date);";
                SqlCommand c = new SqlCommand(query5, con);
                c.Parameters.AddWithValue("@name", textBox1.Text);
                c.Parameters.AddWithValue("@date", DateTime.Now);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Name Added.");
                datagrid();
                
            }
            catch
            {
                MessageBox.Show("Error in adding Name.");
            }
        }

        public void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //add jama
                con.Open();
                string query6 = "INSERT INTO ACCOUNT(NAME, AMOUNT, REMARK, TYPE, DATE) VALUES(@name, @amount, @remark, @credit, @date);";
                SqlCommand c = new SqlCommand(query6, con);
                c.Parameters.AddWithValue("@name", comboBox1.Text);
                c.Parameters.AddWithValue("@amount", textBox2.Text.ToString());
                c.Parameters.AddWithValue("@remark", textBox3.Text);
                c.Parameters.AddWithValue("@credit", credit);
                c.Parameters.AddWithValue("@date", DateTime.Now);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Entry Credited.");
                datagrid();
                account();
            }
            catch
            {
                MessageBox.Show("Error in Credit");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //add udhar
                con.Open();
                string query7 = "INSERT INTO ACCOUNT(NAME, AMOUNT, REMARK, TYPE, DATE) VALUES(@name, @amount, @remark, @debit, @date);";
                SqlCommand c = new SqlCommand(query7, con);
                c.Parameters.AddWithValue("@name", comboBox3.Text);
                c.Parameters.AddWithValue("@amount", textBox5.Text);
                c.Parameters.AddWithValue("@remark", textBox6.Text);
                c.Parameters.AddWithValue("@debit", debit);
                c.Parameters.AddWithValue("@date", DateTime.Now);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Entry Deposit.");
                datagrid();
                account();
            }
            catch
            {
                MessageBox.Show("Error in Deposited.");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // delete name
                con.Open();
                string query8 = "DELETE FROM ACCOUNT_NAME WHERE NAME='@name';";
                SqlCommand c = new SqlCommand(query8, con);
                c.Parameters.AddWithValue("@name", comboBox2.Text);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Name Deleted.");
                datagrid();
                
            }
            catch
            {
                MessageBox.Show("Error in deleting name");
            }
        }
    }
}
