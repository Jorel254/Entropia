using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Hangfire.Annotations;
using System.ComponentModel;

namespace Entropia.Models
{
    class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
