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
namespace Persons
{
    public partial class afradmain : Form
    {
        SpeechSynthesizer ssynthize = new SpeechSynthesizer();
        Color[] mylabels = { Color.Black, Color.DarkGray };
        Random rand = new Random();
        public afradmain()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = rand.Next(mylabels.Length);
            lblnozom.ForeColor = mylabels[x];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("هل تريد تأكيد الخروج من برنامج الأفراد", "مكتب النظم محور روض الفرج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                ssynthize.SpeakAsync("Application Exit");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            officers officer = new officers();
            officer.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            eafaa ea = new eafaa();
            ea.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mens men = new mens();
            men.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            soliders solider = new soliders();
            solider.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            girls girl = new girls();
            girl.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            myjoin joi = new myjoin();
            joi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            retired ret = new retired();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            transport tra = new transport();
            tra.Show();
        }
    }
}
