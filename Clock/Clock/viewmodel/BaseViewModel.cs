using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Clock.viewmodel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
      public  void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string PropertyName = null)
        {
            if (false == object.Equals(backingField, value))
            {

                backingField = value;
                RaisePropertyChanged(PropertyName);
            }
        }

      public     void RaisePropertyChanged([CallerMemberName] string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (PropertyName));
        }
    }
}
