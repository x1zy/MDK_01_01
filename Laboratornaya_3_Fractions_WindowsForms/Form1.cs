using Laboratornaya_3_Fractions_WindowsForms;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratornaya_3_Fractions_WindowsForms
{
    public partial class Form1 : Form, IView
    {
        private Presenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        // Реализация событий интерфейса IView
        public event EventHandler<EventArgs> Fraction1NumeratorChanged;
        public event EventHandler<EventArgs> Fraction2NumeratorChanged;
        public event EventHandler<EventArgs> Fraction1DenominatorChanged;
        public event EventHandler<EventArgs> Fraction2DenominatorChanged;

        // Реализация свойств интерфейса IView
        public string Fraction1Numerator
        {
            get => Fraction1NumeratorTextBox.Text;
            set => Fraction1NumeratorTextBox.Text = value;
        }

        public string Fraction2Numerator
        {
            get => Fraction2NumeratorTextBox.Text;
            set => Fraction2NumeratorTextBox.Text = value;
        }

        public string Fraction1Denominator
        {
            get => Fraction1DenominatorTextBox.Text;
            set => Fraction1DenominatorTextBox.Text = value;
        }

        public string Fraction2Denominator
        {
            get => Fraction2DenominatorTextBox.Text;
            set => Fraction2DenominatorTextBox.Text = value;
        }

        public string ResultText
        {
            get => ResultTextBox.Text;
            set => ResultTextBox.Text = value;
        }

        // Обработчики событий изменения текста в текстовых полях
        private void Fraction1NumeratorTextBox_TextChanged(object sender, EventArgs e)
        {
            Fraction1NumeratorChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Fraction2NumeratorTextBox_TextChanged(object sender, EventArgs e)
        {
            Fraction2NumeratorChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Fraction1DenominatorTextBox_TextChanged(object sender, EventArgs e)
        {
            Fraction1DenominatorChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Fraction2DenominatorTextBox_TextChanged(object sender, EventArgs e)
        {
            Fraction2DenominatorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
