using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DWZ_Scada.Pages.StationPages.OP70
{
    public class OP70Model:INotifyPropertyChanged
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
