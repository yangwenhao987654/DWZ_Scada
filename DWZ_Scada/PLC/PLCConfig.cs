using CommunicationUtilYwh.Communication;
using CommunicationUtilYwh.Communication.PLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZC_DataAcquisition;

namespace DWZ_Scada.PLC
{
    public class PLCConfig
    {
        public MyPlc MyPlc { get; set; }

        public string IP { get; set; }

        public int  Port { get; set; }

        public PLCConfig(MyPLCType type, string iP, int port)
        {
            switch (type)
            {
                case MyPLCType.KeynecePLC:
                    MyPlc = new KeyencePLC();
                    break;
                case MyPLCType.OmornFins:
                    MyPlc = new OmornFins();
                    break;
                case MyPLCType.Siemens_S1200:
                    MyPlc = new SiemensPLC();
                    break;
                default:
                    throw new Exception("PLC Type is Not Support");
                    break;
            }
            IP = iP;
            Port = port;

            SystemParams.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(SystemParams.Instance.OP10_PlcIP))
            {
               //
            }
        }
    }

    public enum MyPLCType
    {
        KeynecePLC,
        OmornFins,
        Siemens_S1200
    }
}
