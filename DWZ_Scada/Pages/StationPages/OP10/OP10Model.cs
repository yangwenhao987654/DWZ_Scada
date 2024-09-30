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
                _deviceId = value;
                OnPropertyChanged();
            }
        }

        private string _exitSN;
        /// <summary>
        /// 出站临时码
        /// </summary>
        public string ExitSN
        {
            get { return _exitSN; }
            set
            {
                _exitSN = value;
                OnPropertyChanged();
            }
        }

        private string _entrySN;
        /// <summary>
        ///进站临时码
        /// </summary>
        public string EntrySN
        {
            get { return _entrySN; }
            set
            {
               
                _entrySN = value;
                OnPropertyChanged();
            }
        }

        private string _v1Result;

        public string V1Result
        {
            get { return _v1Result; }
            set
            {
                _v1Result = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
