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
    public partial class officers : Form
    {
        bool efaa = false;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NOZOM\Documents\afraddata.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NOZOM\Documents\afraddata.mdf;Integrated Security=True;Connect Timeout=30");
        public officers()
        {
            InitializeComponent();
            //panelefaa.Visible = false;
        }
        
        void getalldate()
        {
            try {
                con.Open();
                string query = "select askarynum as'الرقم العسكري',name as'الاسم',numid as'الرقم القومي',age as'العمر',startdate as 'تاريخ التسريح',enddate as'تاريخ الانتهاء' from officers";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                  dataGridView1.DataSource = ds.Tables[0];
                //DataTable dt = new DataTable();
               // sda.Fill(dt);
                //dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
        void getefaaa() {
            con2.Open();
            //con.Open();
            string query2 = "insert into efaat values('" + int.Parse(txtnumaskary.Text) + "',N'" + txtname.Text + "','" + int.Parse(txtid.Text) + "','" + int.Parse(txtage.Text) + "',N'" + txtstartdate.Text + "','" + txtenddate.Text + "')";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("تمت اضافة بيانات الضابط الي الاعفاءات");
            con2.Close();
        }
        void getid() {
            try
            {
                con.Open();
                string query = "select askarynum from officers";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()!="1") {
                    MessageBox.Show("الرقم العسكري غير موجود", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //DataTable dt = new DataTable();
                // sda.Fill(dt);
                //dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            bmp.Save("ss.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            System.Diagnostics.Process.Start("ss.jpg");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            afradmain main = new afradmain();
            main.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtage.Text.Trim()==""||txtenddate.Text.Trim()==""||txtid.Text.Trim()==""||txtname.Text.Trim()==""||txtnumaskary.Text.Trim()==""||txtstartdate.Text.Trim()=="")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات..", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into officers values('" + int.Parse(txtnumaskary.Text)+ "',N'" + txtname.Text + "','" + int.Parse(txtid.Text) + "','"+ int.Parse(txtage.Text) + "',N'" + txtstartdate.Text + "','" + txtenddate.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت اضافة بيانات الضابط");
                    con.Close();
                   getalldate();
                    lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void officers_Load(object sender, EventArgs e)
        {
            getalldate();
            lblrows.Text = (dataGridView1.Rows.Count-1).ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "select askarynum as'الرقم العسكري',name as'الاسم',numid as'الرقم القومي',age as'العمر',startdate as 'تاريخ التسريح',enddate as'تاريخ الانتهاء' from officers where name like N'%" + txtsearch.Text+"%'";
                SqlDataAdapter sda = new SqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
               // getalldate();
               // lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnumaskary.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل الرقم العسكري للضابط..", "Nozom Office", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtid.Text.Trim() == "" || txtname.Text.Trim() == "" || txtnumaskary.Text.Trim() == "" || txtage.Text.Trim() == "" || txtenddate.Text.Trim() == ""||txtstartdate.Text.Trim()=="")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات..", "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update officers set askarynum='" + int.Parse(txtnumaskary.Text) + "',name=N'" + txtname.Text + "',numid='"+int.Parse(txtid.Text)+"',age='" + int.Parse(txtage.Text) + "',startdate=N'" + txtstartdate.Text + "',enddate=N'" +txtenddate.Text + "'where askarynum='" + int.Parse(txtnumaskary.Text) + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تحديث بيانات الضابط", "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    getalldate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtnumaskary.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل الرقم العسكري للضابط..", "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "delete from officers where askarynum='" + int.Parse(txtnumaskary.Text) + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف بيانات الضابط ", "مكتب النظم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    getalldate();
                    lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(mybmp, 0, 0);
        }
        Bitmap mybmp;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            mybmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(mybmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1) {
                try
                {
                    con.Open();
                    string inserquery = "insert into efaat values('"+dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+"',N'"+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "','"+ dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "','"+ dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "','"+ dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "','"+ dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(inserquery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم اعفاء الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string deletequery = "delete from officers where askarynum='"+dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+"'";
                    SqlCommand cmd2 = new SqlCommand(deletequery,con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(" تم حذف الضابط بنجاح من بيانات الضباط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // efaa = true;
                    //DialogResult isefaa = MessageBox.Show("هل تريد اعفاء الضابط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    //MessageBox.Show("تم اعفاء الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                    
                    con.Close();
                    getalldate();
                    //getalldate();
                    // lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dataGridView1.SelectedRows.Count>1) {
                MessageBox.Show("لقد اخترت اكثر من ضابط قم باختيار ضابط واحد ","مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("من فضلك قم باختيار الضابط الذي تريد اعفائه", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //panelefaa.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    con.Open();
                    string inserquery = "insert into retire values('" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "',N'" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(inserquery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت اقالة الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string deletequery = "delete from officers where askarynum='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(deletequery, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(" تم حذف الضابط بنجاح من بيانات الضباط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // efaa = true;
                    //DialogResult isefaa = MessageBox.Show("هل تريد اعفاء الضابط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    //MessageBox.Show("تم اعفاء الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();

                    con.Close();
                    getalldate();
                    //getalldate();
                    // lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("لقد اخترت اكثر من ضابط قم باختيار ضابط واحد ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("من فضلك قم باختيار الضابط الذي تريد اقالته", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    con.Open();
                    string inserquery = "insert into transpoted values('" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "',N'" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(inserquery, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم نقل الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string deletequery = "delete from officers where askarynum='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(deletequery, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show(" تم حذف الضابط بنجاح من بيانات الضباط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // efaa = true;
                    //DialogResult isefaa = MessageBox.Show("هل تريد اعفاء الضابط", "مكتب أفراد محور روض الفرج", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    //MessageBox.Show("تم اعفاء الضابط بنجاح ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();

                    con.Close();
                    getalldate();
                    //getalldate();
                    // lblrows.Text = (dataGridView1.Rows.Count - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("لقد اخترت اكثر من ضابط قم باختيار ضابط واحد ", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("من فضلك قم باختيار الضابط الذي تريد نقله", "مكتب أفراد محور روض الفرج", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
