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
        private Form3 _form3;
        private Form4 _form4;

        public Form2()
        {
            InitializeComponent();
            _form3 = new Form3();
            _form4 = new Form4();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _form3.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 secondForm = new Form1(this);
            secondForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _form4.Show();
        }

        public void AddItemToListView(string text)
        {
            listView1.Items.Add(text);
        }
    }
}