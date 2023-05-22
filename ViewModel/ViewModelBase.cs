using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Matrix.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private object _currentView;
        public object CurrentViewObject
        {
            get { return _currentView; }
            set { _currentView = value; this.OnPropertyChanged(); }
        }

    }
}
