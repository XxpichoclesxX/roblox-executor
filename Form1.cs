using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace SourceKill_V1
{
    public partial class Form1 : Form
    {
        ExploitAPI api = new ExploitAPI();

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            PopulateListBox(listBox1, "./Scripts", "*.txt");
            PopulateListBox(listBox1, "./Scripts", "*.lua");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Abrir";
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string script = richTextBox1.Text;
            api.SendLuaScript(script);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("El archivo no existe");
            }
            else
            {
                richTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            PopulateListBox(listBox1, "./Scripts", "*.txt");
            PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(richTextBox1.Text);
                }
            }

        }
    }
}
