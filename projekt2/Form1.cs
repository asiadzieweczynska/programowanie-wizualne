namespace projekt2
{
    public partial class Form1 : Form
    {
        private Form2 _form2;

        public Form1(Form2 form2)
        {
            InitializeComponent();
            _form2 = form2;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void zamknijOkno(object sender, EventArgs e)
        {
            _form2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedValue = listBox1.SelectedItem.ToString();
                _form2.AddItemToListView(selectedValue);
            }
            _form2.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}