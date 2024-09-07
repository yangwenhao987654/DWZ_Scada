using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10Model:INotifyPropertyChanged
    {

        private string  _deviceId;

        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceID
        {
            get { return _deviceId; }
            set
            {
                OnPropertyChanged();
                _deviceId = value;
            }
        }

        private string _tempSN;

        /// <summary>
        /// 临时码
        /// </summary>
        public string TempSN
        {
            get { return _tempSN; }
            set
            {
                OnPropertyChanged(); 
                _tempSN = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
