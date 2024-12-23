using System;
using System.Text;
using System.Windows.Forms;

namespace Laboratornaya_3_Fractions_WindowsForms
{
    internal class Presenter
    {
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;

            // Подписываемся на события изменения текста в текстовых полях
            _view.Fraction1NumeratorChanged += new EventHandler<EventArgs>(OnSetFraction1Numerator);
            _view.Fraction2NumeratorChanged += new EventHandler<EventArgs>(OnSetFraction2Numerator);
            _view.Fraction1DenominatorChanged += new EventHandler<EventArgs>(OnSetFraction1Denominator);
            _view.Fraction2DenominatorChanged += new EventHandler<EventArgs>(OnSetFraction2Denominator);
        }

        // Обработка события, установка нового значения
        public void OnSetFraction1Numerator(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void OnSetFraction2Numerator(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void OnSetFraction1Denominator(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void OnSetFraction2Denominator(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void RefreshView()
        {
            // Проверяем, что оба значения введены
            if (!string.IsNullOrWhiteSpace(_view.Fraction1Numerator) &&
                !string.IsNullOrWhiteSpace(_view.Fraction2Numerator) &&
                !string.IsNullOrWhiteSpace(_view.Fraction1Denominator) &&
                !string.IsNullOrWhiteSpace(_view.Fraction2Denominator))
            {
                Calculate(null, null);
            }
            else
            {
                _view.ResultText = string.Empty; // Не выводим ничего, если данные некорректны
            }
        }

        public void Calculate(object sender, EventArgs e)
        {
            // Проверяем, что все текстовые поля не пустые
            if (string.IsNullOrWhiteSpace(_view.Fraction1Numerator) ||
                string.IsNullOrWhiteSpace(_view.Fraction1Denominator) ||
                string.IsNullOrWhiteSpace(_view.Fraction2Numerator) ||
                string.IsNullOrWhiteSpace(_view.Fraction2Denominator))
            {
                return; // Если хотя бы одно поле пустое, вычисления не выполняются
            }

            if (!TryGetFraction(_view.Fraction1Numerator, _view.Fraction1Denominator, out Fraction f1))
                return;

            if (!TryGetFraction(_view.Fraction2Numerator, _view.Fraction2Denominator, out Fraction f2))
                return;

            StringBuilder results = new StringBuilder();

            try
            {
                // Вывод арифметических действий в столбец
                results.AppendLine($"{f1} + {f2} = {f1 + f2}");
                results.AppendLine($"{f1} - {f2} = {f1 - f2}");
                results.AppendLine($"{f1} * {f2} = {f1 * f2}");
                results.AppendLine($"{f1} / {f2} = {f1 / f2}");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка деления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.ResultText = results.ToString();
        }

        private bool TryGetFraction(string numeratorText, string denominatorText, out Fraction fraction)
        {
            fraction = null;

            if (!int.TryParse(numeratorText, out int numerator))
            {
                MessageBox.Show("Введите корректный числитель.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(denominatorText, out int denominator))
            {
                MessageBox.Show("Введите корректный знаменатель.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                fraction = new Fraction(numerator, denominator);
                return true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка дроби", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}