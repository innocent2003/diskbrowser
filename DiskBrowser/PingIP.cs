using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskBrowser
{
    public partial class PingIP : Form
    {
        public PingIP()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String range = textBox1.Text;
            String firstIP = textBox2.Text;
            String ip = String.Concat(range, firstIP);
            Ping p = new Ping();
            PingReply r = p.Send(ip);
            if(r.Status == IPStatus.Success) {
                online.Items.Add(ip);
            }
            else
            {
                offline.Items.Add(ip);
            }
            int nextIP = Convert.ToInt16(textBox2.Text);
            nextIP++;
            textBox2.Text = nextIP.ToString();
        }
    }
}
