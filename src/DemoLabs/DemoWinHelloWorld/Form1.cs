namespace DemoWinHelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox2.Text);

            int result = a + b;
            string message = string.Format("Sum of {0} and {1} is {2}", a, b, result);

            label3.Text = message;
        }


    }
}
