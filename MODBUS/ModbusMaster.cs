
using Program.MODBUS.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program.Form1;

namespace Program.MODBUS
{
    class ModbusMaster
    {
       
        MySerialPort mySerialPort;
        Queue<byte []> requests = new Queue<byte[]>();
        Queue<byte []> requestsForWriteData = new Queue<byte[]>();
        
        public int count;
       
       // byte[] dataBuffer = new byte[6];

        public ModbusMaster()
        {
            mySerialPort = new MySerialPort(dataRecivedSuccessHandler, dataRecivedFailureHandler, requests, requestsForWriteData);
            

            mySerialPort.open("COM3");
        }


        public void addRequest(byte [] buffer)
        {
            byte[] request = ModbusCRC16.addCRC16(buffer);
           
            requests.Enqueue(request);
        }


        internal void oprosSlaves()
        {

            //if (requests.Count > 0 || requestsForWriteData.Count > 0)
            //{
            //    //Console.WriteLine("Requests count : " + requests.Count);
            //    mySerialPort.opros();         
            //}

            mySerialPort.opros();
            count = requests.Count;

        }


        public void writeData(byte [] buffer)
        {
            byte[] writeBuffer = ModbusCRC16.addCRC16(buffer);

            requestsForWriteData.Enqueue(writeBuffer);

           // mySerialPort.opros(); в другом потоке вызывается
        }


        public void dataRecivedSuccessHandler(byte [] reciveBuffer, byte[] lastSendBuffer)
        {
            Console.Write("Пришло   ");
            for (int i = 0; i < reciveBuffer.Length; i++)
            {
                Console.Write(reciveBuffer[i] + " ");
            }
            Console.WriteLine();
            
            //Console.WriteLine(ConvertModbusData.convertToSingle (reciveBuffer));


            // ModbusSlaves.parseResponse(lastSendBuffer, reciveBuffer);
             ModbusNodes.parseResponse(lastSendBuffer, reciveBuffer);
            
        }


        public void dataRecivedFailureHandler(string err, byte [] lastSendBuffer)
        {

            Console.Write("Ошибка   ");
            for (int i = 0; i < lastSendBuffer.Length; i++)
            {
                Console.Write(lastSendBuffer[i] + " ");
            }
            Console.WriteLine(err);
            //ModbusSlaves.parseResponse(lastSendBuffer, lastSendBuffer);
            ModbusNodes.parseResponse(lastSendBuffer, lastSendBuffer);
        }
    }
}
