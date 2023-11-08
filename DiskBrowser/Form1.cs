using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ShowDrives()
        {
            treeView1.BeginUpdate();
            string[] drives = Directory.GetLogicalDrives(); 
            foreach (string adrive in drives) {
                TreeNode tn = new TreeNode(adrive);
                treeView1.Nodes.Add(tn);
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }
        public void ShowFileNames()
        {
            DirectoryInfo di = new DirectoryInfo(treeView1.SelectedNode.FullPath);
            FileInfo[] fiarray = { };
            ListViewItem item;
            imageList1 = new ImageList();
            listView1.Items.Clear();   
            listView1.SmallImageList = imageList1;
            if(di.Exists)
            {
                fiarray = di.GetFiles();    

            }
            listView1.BeginUpdate();
            foreach (FileInfo fi in fiarray)
            {
                //item = new ListViewItem(fi.Name);
                //listView1.Items.Add(item);
                Icon iconForFile;
                item = new ListViewItem(fi.Name);
                listView1.Items.Add(item);
                iconForFile = SystemIcons.WinLogo;

                if (!imageList1.Images.ContainsKey(fi.Extension))
                {
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName);
                    imageList1.Images.Add(fi.Extension, iconForFile);   

                }
                item.ImageKey = fi.Extension;   
                item.SubItems.Add(fi.Length.ToString() );
                item.SubItems.Add(fi.LastWriteTime.ToString() );
                item.SubItems.Add(GetAtts(fi));
            }
            listView1.EndUpdate();  
        }
        private string GetAtts(FileInfo fi)
        {
            string atts = "";
            if((fi.Attributes & FileAttributes.Archive) != 0) { atts += "A"; }
            if ((fi.Attributes & FileAttributes.Hidden) != 0) { atts += "H"; }
            if ((fi.Attributes & FileAttributes.ReadOnly) != 0) { atts += "R"; }
            if ((fi.Attributes & FileAttributes.System) != 0) { atts += "S"; }
            return atts;
        }    

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDrives();
        }
        public void AddDirs(TreeNode tn)
        {
            string path = tn.FullPath;
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diarray = { };
            try
            {
                if (di.Exists)
                {
                    diarray = di.GetDirectories();
                }
            }
            catch
            {
                return;
            }
            foreach (DirectoryInfo d in diarray)
            {
                TreeNode tndir = new TreeNode(d.Name);  
                tn.Nodes.Add(tndir);    
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFileNames();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();
            foreach(TreeNode tn in treeView1.Nodes) { 
                AddDirs(tn);
            }
            treeView1.EndUpdate();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string diskfile = treeView1.SelectedNode.FullPath;
            if(!diskfile.EndsWith ("\\"))
            {
                diskfile = diskfile + "\\";
            }
            diskfile += listView1.FocusedItem.Text;
            if(File.Exists(diskfile))
            {
                Process.Start(new ProcessStartInfo { FileName = diskfile,UseShellExecute = true});    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PingIP a = new PingIP();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Processes123 b = new Processes123();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CPUMonitor c = new CPUMonitor();
            c.Show();
        }
    }
}
