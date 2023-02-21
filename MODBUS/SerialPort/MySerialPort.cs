using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Program.MODBUS;

namespace Program
{
    class MySerialPort : SerialPort
    {
        
        public byte[] lastSendBuffer;
        public bool crcOK;
        public bool reciveDataOK;
        public bool sendDataOK=false;
        private Action<byte [],  byte[]> dataRecivedSuccessHandler;
        private Action <string, byte[]> dataRecivedFailureHandler;

        Queue<byte[]> requests;
        Queue<byte[]> requestsForWriteData;
        int waitCount;


        public MySerialPort(Action<byte [],byte[]> successHandler, Action<string, byte[]> failureHandler, Queue<byte[]> requests, Queue<byte[]> requestsForWriteData) : base()
        {
            this.dataRecivedSuccessHandler = successHandler;
            this.dataRecivedFailureHandler = failureHandler;
            this.requests = requests;
            this.requestsForWriteData = requestsForWriteData;

            base.BaudRate = 19200;
            base.Parity = Parity.None;
            base.StopBits = StopBits.One;
            base.DataBits = 8;
            base.ReadTimeout = 1;
           // base.ReceivedBytesThreshold = 7;
            

            base.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        }

       

        public void open(string portName)
        {
            try
            {
                if (base.IsOpen)
                {
                    base.Close();
                }
                base.PortName = portName;
                base.Open();
            }
            catch
            {

            }
           
        }

        public void opros()
        {
           
            crcOK = false;
            reciveDataOK = false;
                    
            if (!sendDataOK)
            {
                if(requestsForWriteData.Count > 0)
                {
                    sendDataOK = true;

                    byte[] writeBuffer = requestsForWriteData.Dequeue();

                    lastSendBuffer = writeBuffer;

                    int count = ConvertModbusData.getWriteCountByte(writeBuffer);

                    base.ReceivedBytesThreshold = 8;

                    //Console.WriteLine("Пишем: " + count + " байтов");

                    Console.Write("Пишем    ");
                    for (int i = 0; i < writeBuffer.Length; i++)
                    {
                        Console.Write(writeBuffer[i] + " ");
                    }
                    Console.WriteLine();
                    

                    base.Write(writeBuffer, 0, writeBuffer.Length);
                }

                if (requests.Count > 0)
                {
                    sendDataOK = true;
                    byte[] sendBuffer = requests.Dequeue();

                    lastSendBuffer = sendBuffer;
                    int countByte = ConvertModbusData.getRequestCountByte(sendBuffer);

                    base.ReceivedBytesThreshold = countByte + 5;
                    // Console.WriteLine("Ждем: " + countByte + " байтов " + sendDataOK);
                    Console.Write("Пишем    ");
                    for (int i = 0; i < sendBuffer.Length; i++)
                    {
                        Console.Write(sendBuffer[i] + " ");
                    }
                    Console.WriteLine();
                   

                    base.Write(sendBuffer, 0, sendBuffer.Length);
                }
            }
            else
            {
                waitCount++;
                if (waitCount > 5)
                {
                    dataRecivedFailureHandler("Модуль не овечает...", lastSendBuffer);
                    waitCount = 0;
                    sendDataOK = false;
                }
            }
            //else
            //{
            //    waitCount++;
            //    //Console.WriteLine("Ждем: " + waitCount);

            //    //for (int i = 0; i < lastSendBuffer.Length; i++)
            //    //{
            //    //    Console.Write(lastSendBuffer[i] + " ");
            //    //}
            //    //Console.WriteLine();

            //    if (waitCount > 5)
            //    {
            //        dataRecivedFailureHandler("Модуль не овечает...", lastSendBuffer);

            //        if (lastSendBuffer[1] == 16)
            //        {
            //            requestsForWriteData.Dequeue();

            //        }
            //        if (lastSendBuffer[1] == 3)
            //        {
            //            requests.Dequeue();
            //        }
            //        waitCount = 0;
            //        sendDataOK = false;
            //    }
            //}          
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            waitCount = 0;
            //Console.WriteLine("Что то пришло............");
            if (!sendDataOK)
            {
               
                SerialPort sport = (SerialPort)sender;
              
                dataRecivedFailureHandler("байты без запроса", lastSendBuffer);
                sendDataOK = false;
                return;
            }
            
            
            reciveDataOK = true;

            SerialPort sp = (SerialPort)sender;
           

            int buferSize = sp.BytesToRead;
            byte [] reciveBuffer = new byte[buferSize];

            for (int i = 0; i < buferSize; i++)
            {
                byte bt = (byte)sp.ReadByte();
                reciveBuffer[i] = bt;
                //Console.Write(reciveBuffer[i] + " ");
            }
            //Console.WriteLine();


            if (!ModbusCRC16.checkCRC16(reciveBuffer))
            {
               // Console.WriteLine("Помехи");
                crcOK = false;
                
                dataRecivedFailureHandler("CRC FALSE",lastSendBuffer);
                sendDataOK = false;
                return;
            } else
            {
                //Console.WriteLine("Корректные данные:   ");
                
                dataRecivedSuccessHandler(reciveBuffer,lastSendBuffer);

                //Console.WriteLine(reciveBuffer[1]);

                //if (reciveBuffer[1] == 16)
                //{
                //    requestsForWriteData.Dequeue();

                //}
                //if (reciveBuffer[1] == 3)
                //{
                //    requests.Dequeue();
                //}

               

                sendDataOK = false;

            }
           
        }
    }
}
