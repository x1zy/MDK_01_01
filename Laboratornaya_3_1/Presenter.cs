using System;

namespace Laboratornaya_3_1
{
    public class Presenter
    {
        private readonly IView _view;
        private Fraction _fraction1;
        private Fraction _fraction2;
        //В конструктор передается конкретный экземпляр представления и происходит подписка на все нужные события.
        public Presenter(IView view)
        {
            _view = view;

            // Инициализируем начальные значения
            _fraction1 = new Fraction(0, 1);
            _fraction2 = new Fraction(0, 1);

            // Подписываемся на события из представления
            _view.SetFraction1Numerator += OnSetFraction1Numerator;
            _view.SetFraction1Denominator += OnSetFraction1Denominator;
            _view.SetFraction2Numerator += OnSetFraction2Numerator;
            _view.SetFraction2Denominator += OnSetFraction2Denominator;

            RefreshView();
        }

        private void OnSetFraction1Numerator(object sender, EventArgs e)
        {
            if (int.TryParse(_view.Fraction1Numerator, out int numerator))
            {
                _fraction1 = new Fraction(numerator, _fraction1.Denominator); // Обновляем только числитель
                RefreshView();
            }
            else
            {
                _view.ResultText = "Ошибка: числитель первой дроби должен быть целым числом.";
            }
        }

        private void OnSetFraction1Denominator(object sender, EventArgs e)
        {
            if (int.TryParse(_view.Fraction1Denominator, out int denominator))
            {
                if (denominator == 0)
                {
                    _view.ResultText = "Ошибка: знаменатель первой дроби не может быть равен нулю.";
                    return;
                }
                _fraction1 = new Fraction(_fraction1.Numerator, denominator); // Обновляем только знаменатель
                RefreshView();
            }
            else
            {
                _view.ResultText = "Ошибка: знаменатель первой дроби должен быть целым числом.";
            }
        }

        private void OnSetFraction2Numerator(object sender, EventArgs e)
        {
            if (int.TryParse(_view.Fraction2Numerator, out int numerator))
            {
                _fraction2 = new Fraction(numerator, _fraction2.Denominator); // Обновляем только числитель
                RefreshView();
            }
            else
            {
                _view.ResultText = "Ошибка: числитель второй дроби должен быть целым числом.";
            }
        }

        private void OnSetFraction2Denominator(object sender, EventArgs e)
        {
            if (int.TryParse(_view.Fraction2Denominator, out int denominator))
            {
                if (denominator == 0)
                {
                    _view.ResultText = "Ошибка: знаменатель второй дроби не может быть равен нулю.";
                    return;
                }
                _fraction2 = new Fraction(_fraction2.Numerator, denominator); // Обновляем только знаменатель
                RefreshView();
            }
            else
            {
                _view.ResultText = "Ошибка: знаменатель второй дроби должен быть целым числом.";
            }
        }

        private void RefreshView()
        {
            // Проверяем, что все поля заполнены и корректны
            if (string.IsNullOrWhiteSpace(_view.Fraction1Numerator) ||
                string.IsNullOrWhiteSpace(_view.Fraction1Denominator) ||
                string.IsNullOrWhiteSpace(_view.Fraction2Numerator) ||
                string.IsNullOrWhiteSpace(_view.Fraction2Denominator))
            {
                _view.ResultText = "Пожалуйста, заполните все поля.";
                return;
            }

            try
            {
                Fraction sum = _fraction1 + _fraction2;
                Fraction difference = _fraction1 - _fraction2;
                Fraction product = _fraction1 * _fraction2;
                Fraction quotient = _fraction1 / _fraction2;

                _view.ResultText = $"{_fraction1} + {_fraction2} = {sum}\n" +
                                   $"{_fraction1} - {_fraction2} = {difference}\n" +
                                   $"{_fraction1} * {_fraction2} = {product}\n" +
                                   $"{_fraction1} / {_fraction2} = {quotient}\n";
            }
            catch (DivideByZeroException ex)
            {
                _view.ResultText = "Ошибка: " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                _view.ResultText = "Ошибка: " + ex.Message;
            }
        }
    }
}