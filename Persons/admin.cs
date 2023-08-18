using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Persons
{
    public partial class admin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NOZOM\Documents\afraddata.mdf;Integrated Security=True;Connect Timeout=30");
        public admin()
        {
            InitializeComponent();
            panel1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login log = new login();
            log.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtadminpass.Text == "54321")
            {
                //panel2.Visible = false;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("خطأ في كلمة السر", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Trim() == "" || txtpass.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات..", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update login set username='" + txtusername.Text + "',pass='" + txtpass.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("لقد تم تحديث اسم المستخدم وكلمة المرور");
                    con.Close();
                    this.Hide();
                    login log = new login();
                    log.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtadminpass.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtpass.Text = "";
            txtusername.Text = "";
        }
    }
}
