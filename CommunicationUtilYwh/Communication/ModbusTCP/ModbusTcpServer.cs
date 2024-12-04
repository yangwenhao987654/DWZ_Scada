using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Core;

namespace CommunicationUtilYwh.Communication.ModbusTCP
{
    public class ModbusTcpServer
    {
        private HslCommunication.ModBus.ModbusTcpServer modbusServer;
        public ModbusTcpServer(int port)
        {
            modbusServer = new HslCommunication.ModBus.ModbusTcpServer();
            modbusServer.Port = port;
            modbusServer.Station = 1;
            modbusServer.DataFormat = DataFormat.ABCD;
            modbusServer.Port = port;
            //modbusServer.OnDataSend
            //modbusServer.WriteCustomer()
            //modbusServer.Write();
        }

        public void Start()
        {
            if (modbusServer==null)
            {
                throw new Exception("server is not init ");
            }

            if (modbusServer.IsStarted)
            {
                throw new Exception("server is Started");
            }
            modbusServer.ServerStart();
        }

    }
}
