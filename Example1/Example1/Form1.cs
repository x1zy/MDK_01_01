namespace Example1
{
    public partial class Form1 : Form, IView
    {
        Presenter presenter;
        public Form1()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }
        public event EventHandler<EventArgs> SetA;
        public event EventHandler<EventArgs> SetB;
        public string Sq
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public double InputA
        {
            set
            {
                textBox1.Text = value.ToString();
            }
            get { return Convert.ToDouble(textBox1.Text); }
        }
        public double InputB
        {
            set
            {
                textBox2.Text = value.ToString();
            }
            get { return Convert.ToDouble(textBox2.Text); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (SetB != null)
                SetB(this, EventArgs.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (SetA != null)
                SetA(this, EventArgs.Empty);
        }

    }
}
