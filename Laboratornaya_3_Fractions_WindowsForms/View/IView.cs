using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_3_Fractions_WindowsForms
{
    public interface IView
    {
        string Fraction1Numerator { get; set; }
        string Fraction1Denominator { get; set; }
        string Fraction2Numerator { get; set; }
        string Fraction2Denominator { get; set; }
        string ResultText { get; set; }
        // Событие ввода значения 
        event EventHandler <EventArgs> Fraction1NumeratorChanged;
        event EventHandler <EventArgs> Fraction1DenominatorChanged;
        event EventHandler <EventArgs> Fraction2NumeratorChanged;
        event EventHandler <EventArgs> Fraction2DenominatorChanged;
    }
}
