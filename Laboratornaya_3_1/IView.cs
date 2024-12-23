using System;

namespace Laboratornaya_3_1
{
    public interface IView
    {
        string Fraction1Numerator { get; set; }
        string Fraction1Denominator { get; set; }
        string Fraction2Numerator { get; set; }
        string Fraction2Denominator { get; set; }
        string ResultText { get; set; }

        event EventHandler<EventArgs> SetFraction1Numerator;
        event EventHandler<EventArgs> SetFraction1Denominator;
        event EventHandler<EventArgs> SetFraction2Numerator;
        event EventHandler<EventArgs> SetFraction2Denominator;
    }
}