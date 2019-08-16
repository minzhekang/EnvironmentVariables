using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentVariables
{
        public partial class Form1 : Form{


        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFunc()
        {
            string PathVar = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);

            string[] listsingle = PathVar.Split(';');
            Console.WriteLine(listsingle[1]);
            foreach (string singlevalue in listsingle)
            {
                
                listBox1.Items.Add(singlevalue);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.HorizontalScrollbar = true;
            LoadFunc();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index, textBox1.Text);

            var alllist = new List<string>();
            foreach(var var in listBox1.Items)
            {
                alllist.Add(var.ToString());
                
            }
            string allPath = String.Join(";", alllist);
            Environment.SetEnvironmentVariable("Path", allPath, EnvironmentVariableTarget.User);
            listBox1.Items.Clear();
            LoadFunc();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
                textBox1.Text = listBox1.SelectedItem.ToString();
        }
    }
}
