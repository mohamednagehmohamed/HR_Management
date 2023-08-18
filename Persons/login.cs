using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Data.SqlClient;
namespace Persons
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NOZOM\Documents\afraddata.mdf;Integrated Security=True;Connect Timeout=30");
        SpeechSynthesizer ssybthize = new SpeechSynthesizer();
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("هل تريد تأكيد الخروج من برنامج الأفراد","مكتب النظم محور روض الفرج",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (exit==DialogResult.Yes) {
                ssybthize.SpeakAsync("Application Exit");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls) {
                if (c is TextBox) {
                    c.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Trim() == "" || txtpass.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات..", "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "select count(*) from login where username='" + txtusername.Text + "'and pass='" + txtpass.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        afradmain main = new afradmain();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("خطأ في اسم المستخدم وكلمة السر", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin ad = new admin();
            ad.Show();
        }
    }
}
