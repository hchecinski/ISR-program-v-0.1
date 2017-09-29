using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISR_program
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _login = string.Empty;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public void OnPropertyChanged(string nazwaWlasciwosc)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasciwosc));
        }
    }
}
