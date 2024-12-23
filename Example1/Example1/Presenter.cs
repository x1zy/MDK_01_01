using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    internal class Presenter
    {
        private Model _model = new Model();
        private IView _view;
        //В конструктор передается конкретный экземпляр представления и происходит подписка на все нужные события.
        public Presenter(IView view)
        {
            _view = view;
            _view.SetA += new EventHandler<EventArgs>(OnSetA);
            _view.SetB += new EventHandler<EventArgs>(OnSetB);
            RefreshView();
        }
        // Обработка события, установка нового значения
        public void OnSetA(object sender, EventArgs e)
        {
            _model.A = _view.InputA;
            RefreshView();
        }
        // Обработка события, установка нового значения 
        public void OnSetB(object sender, EventArgs e)
        {
            _model.B = _view.InputB;
            RefreshView();
        }
        // Обновление Представления новыми значениями модели.По сути Binding (привязка) значений модели к Представлению. 
        public void RefreshView()
        {
            _view.Sq = _model.square().ToString();

        }
    }
}
