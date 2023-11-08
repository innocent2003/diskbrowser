using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskBrowser
{
    public partial class Processes123 : Form
    {
        public Processes123()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string text = startTextBox.Text;
            Process process = new Process();
            process.StartInfo.FileName = text;
            process.Start();
            loadProcessList();
        }
        private void loadProcessList()
        {
            listView1.Items.Clear();
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.ProcessName);
                item.Tag = process;
                listView1.Items.Add(item);
            }
        }

        private void Processes123_Load(object sender, EventArgs e)
        {
           loadProcessList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //ListViewItem item = listView1.SelectedItems[0];
            //Process process =  (Process)item.Tag;
            //process.Kill();
            //loadProcessList();


            //if (listView1.SelectedItems.Count > 0)
            //{
            //    ListViewItem item = listView1.SelectedItems[0];
            //    Process process = (Process)item.Tag;

            //    try
            //    {
            //        process.Kill();
            //        process.WaitForExit();
            //        loadProcessList();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error stopping the process: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }
    }
}
