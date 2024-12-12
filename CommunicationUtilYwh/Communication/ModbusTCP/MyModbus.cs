using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace CommunicationUtilYwh.Communication.ModbusTCP
{
    public class MyModbus:IDisposable
    {
        private ModbusIpMaster master;

        private TcpClient tcpClient = new TcpClient();

        public string IP { get; set; }

        public int Port { get; set; }

        private byte _stationNum = 1;

        public byte StationNum
        {
            get
            {
                return _stationNum;
            }
            set
            {
                if (_stationNum!=value)
                {
                    _stationNum =value;
                }
            }
        }

        public bool IsConnect
        {
            get
            {
                return tcpClient!=null && tcpClient.Connected;
            }
        }

        public MyModbus(string ip,int port)
        {
            IP =ip;
            Port = port;
        }

        public MyModbus()
        {
            //master = ModbusIpMaster.CreateIp(tcpClient);
        }

        private bool Connect()
        {
            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                {
                    return true;
                }
              
            }
            tcpClient = new TcpClient();
            master = ModbusIpMaster.CreateIp(tcpClient);
            tcpClient.Connect(IP, Port);
            if (IsConnect)
            {
                master.Transport.ReadTimeout = _reviceTimeOut;
                tcpClient.ReceiveTimeout =_reviceTimeOut;
                tcpClient.SendTimeout =_reviceTimeOut;
                master.Transport.WriteTimeout = _reviceTimeOut;
            }
            return tcpClient.Connected;
        }



        private int _reviceTimeOut = 3000;

        public int ReviceTimeOut
        {
            get
            {
                return _reviceTimeOut;
            }
            set
            {
                _reviceTimeOut =value;
                if (tcpClient!=null)
                {
                    tcpClient.ReceiveTimeout = _reviceTimeOut;
                }
            }
        }

        public bool Connect(string ip ,int port)
        {
           
            IP = ip;
            Port = port;
            Connect();
            return IsConnect;
        }


        public bool[] ReadCoils(ushort startAddr,ushort length)
        {
           
            bool[] bools = master.ReadCoils(StationNum,startAddr,length);
            return bools;
        }

        public ushort[] ReadHoldingRegisters(ushort startAddr, ushort length)
        {
            ushort[] bools = master.ReadHoldingRegisters(StationNum, startAddr, length);
            return bools;
        }

        public ushort ReadUInt16(ushort startAddr)
        {
            ushort[] bools = master.ReadHoldingRegisters(StationNum, startAddr,1);

            //short[] arr = master.ReadInputs(StationNum, startAddr, 1);
            return bools[0];
        }

        public short ReadInt16(ushort startAddr)
        {
            ushort[] holdingRegisters = master.ReadHoldingRegisters(StationNum, startAddr, 1);

            short[] values = Array.ConvertAll(holdingRegisters, u => (short)u);
            return values[0];
        }


        public bool[] ReadCoils(byte slaveAddr ,ushort startAddr, ushort length)
        {
            StationNum =slaveAddr;
            bool[] bools = master.ReadCoils(StationNum, startAddr, length);
            return bools;
        }

        public ushort[] ReadHoldingRegisters(byte slaveAddr, ushort startAddr, ushort length)
        {
            StationNum = slaveAddr;
            ushort[] bools = master.ReadHoldingRegisters(StationNum, startAddr, length);
            return bools;
        }

        public void Dispose()
        {
            master?.Dispose();
            tcpClient?.Dispose();
        }
    }
}
