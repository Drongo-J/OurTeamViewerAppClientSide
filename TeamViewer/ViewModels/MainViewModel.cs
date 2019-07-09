using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer.Commands;

namespace TeamViewer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ConnectCommand ConnectCommand => new ConnectCommand(this);
        private string ipAddress;

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IpAddress)));
            }
        }

    }
}
