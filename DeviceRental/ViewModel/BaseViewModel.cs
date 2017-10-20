using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DeviceRentalManagement.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly Entities entities = EntitiesManager.GetEntitiesInstance();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyLamda)
        {
            var me = propertyLamda as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException(
                    "You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            var handler = PropertyChanged;
            if (null == handler) return;
            handler(this, new PropertyChangedEventArgs(me.Member.Name));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
