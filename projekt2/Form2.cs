using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 secondForm = new Form3();
            secondForm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1();
            secondForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 secondForm = new Form4();
            secondForm.Show();
        }

        public void AddItemToListView(string text)
        {
            listView1.Items.Add(text);
        }
    }
}