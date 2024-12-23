using System;
using System.Windows;

namespace Laboratornaya_3_1
{
    public partial class MainWindow : Window, IView
    {
        private Presenter _presenter;

        public MainWindow()
        {
            InitializeComponent();
            _presenter = new Presenter(this);

            // Подписываемся на события изменения текста
            Fraction1NumeratorTextBox.TextChanged += (s, e) => SetFraction1Numerator?.Invoke(this, EventArgs.Empty);
            Fraction1DenominatorTextBox.TextChanged += (s, e) => SetFraction1Denominator?.Invoke(this, EventArgs.Empty);
            Fraction2NumeratorTextBox.TextChanged += (s, e) => SetFraction2Numerator?.Invoke(this, EventArgs.Empty);
            Fraction2DenominatorTextBox.TextChanged += (s, e) => SetFraction2Denominator?.Invoke(this, EventArgs.Empty);
        }

        public string Fraction1Numerator
        {
            get => Fraction1NumeratorTextBox.Text;
            set => Fraction1NumeratorTextBox.Text = value;
        }

        public string Fraction1Denominator
        {
            get => Fraction1DenominatorTextBox.Text;
            set => Fraction1DenominatorTextBox.Text = value;
        }

        public string Fraction2Numerator
        {
            get => Fraction2NumeratorTextBox.Text;
            set => Fraction2NumeratorTextBox.Text = value;
        }

        public string Fraction2Denominator
        {
            get => Fraction2DenominatorTextBox.Text;
            set => Fraction2DenominatorTextBox.Text = value;
        }

        public string ResultText
        {
            get => ResultTextBlock.Text;
            set => ResultTextBlock.Text = value;
        }

        public event EventHandler<EventArgs> SetFraction1Numerator;
        public event EventHandler<EventArgs> SetFraction1Denominator;
        public event EventHandler<EventArgs> SetFraction2Numerator;
        public event EventHandler<EventArgs> SetFraction2Denominator;
    }
}