using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceHere
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///вызывает событие propertychanged, позволяющее обновить представление.Передайте ваше частное свойство, новое значение, 
        /// а также имя свойства, но это обычно делается за вас.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">частное поле, которое используется для «установки"</param>
        /// <param name="value">новое значение этого свойства</param>
        /// <param name="propertyName">обычно не нужно указывать это, но это имя свойства/field</param>
        public void RaisePropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// вызывает событие propertychanged, позволяющее обновить представление. передать частное свойство, новое значение,
        /// и метод обратного вызова, содержащий новое значение в качестве параметра
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">частное поле, которое используется для «установки"</param>
        /// <param name="value">новое значение этого свойства</param>
        /// <param name="propertyName">обычно не нужно указывать это, но это имя свойства/field</param>
        /// <param name="callbackMethod">метод, который вызывается после и содержит значение в качестве параметра</param>
        public void RaisePropertyChanged<T>(ref T property, T value, Action<T> callbackMethod, [CallerMemberName] string propertyName = "")
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            callbackMethod?.Invoke(value);
        }
        /// <summary>
        /// вызывает событие propertychanged, позволяющее обновить представление. Передайте ваше частное свойство, новое значение,
        /// и метод обратного вызова, а также имя свойства, но это обычно делается за вас.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">the private field that is used for "setting"</param>
        /// <param name="value">the new value of this property</param>
        /// <param name="propertyName">dont need to specify this usually, but the name of the property/field</param>
        /// <param name="callbackMethod">the method that gets called after </param>
        public void RaisePropertyChanged<T>(ref T property, T value, Action callbackMethod, [CallerMemberName] string propertyName = "")
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            callbackMethod?.Invoke();
        }
    }
}
