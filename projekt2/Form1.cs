namespace projekt2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void zamknijOkno(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedValue = listBox1.SelectedItem.ToString();
                Form2 secondForm = new Form2();
                secondForm.AddItemToListView(selectedValue);
                secondForm.Show();
            }
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
