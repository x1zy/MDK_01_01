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
            get
            {
                // ���������, �� �������� �� ����� ������ ��� ������������
                if (double.TryParse(textBox1.Text, out double result))
                {
                    return result;
                }
                return 0; // ���������� 0, ���� �������� �����������
            }
        }

        public double InputB
        {
            set
            {
                textBox2.Text = value.ToString();
            }
            get
            {
                // ���������, �� �������� �� ����� ������ ��� ������������
                if (double.TryParse(textBox2.Text, out double result))
                {
                    return result;
                }
                return 0; // ���������� 0, ���� �������� �����������
            }
        }

        // ����������� �������
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (SetA != null && double.TryParse(textBox1.Text, out _))
            {
                SetA(this, EventArgs.Empty);
            }
            else
            {
                Sq = string.Empty; // ���������� ���������, ���� ������ �����������
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (SetB != null && double.TryParse(textBox2.Text, out _))
            {
                SetB(this, EventArgs.Empty);
            }
            else
            {
                Sq = string.Empty; // ���������� ���������, ���� ������ �����������
            }
        }

    }
}
