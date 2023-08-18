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
    public partial class Form1 : Form
    {
        SpeechSynthesizer ssybthize = new SpeechSynthesizer();
        int startpoint = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint++;
            progressBar1.Value = startpoint;
            if (startpoint == 100)
            {
                startpoint = 0;
                progressBar1.Value = 0;
                timer1.Enabled = false;
                this.Hide();
                login log = new login();
                log.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ssybthize.SelectVoiceByHints(VoiceGender.Female);
            ssybthize.SpeakAsync("Welcome To Road Elfarag Road");
        }
    }
}
