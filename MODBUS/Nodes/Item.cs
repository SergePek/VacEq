using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS.Nodes
{
    public class Item
    {
        int type;
        public byte register;
        public byte[] requestBuffer;

        public byte[] data;

        public delegate void ParamSuccessHandler(byte[] data);

        public delegate void ParamFailureHandler();

        public event ParamSuccessHandler SuccessNotify;

        public event ParamFailureHandler FailureNotify;


        public Item(byte [] requestBuffer, int type)
        {
            this.requestBuffer = requestBuffer;
            this.register = requestBuffer[3];
            this.type = type;
        }

        internal void setData(byte[] buffer)
        {
            data = buffer;
            Console.WriteLine("Присвоили....................................................");
            Console.WriteLine();

            SuccessNotify?.Invoke(data);
        }

        internal void cleanData()
        {
            FailureNotify?.Invoke();
        }

        public byte[] getReguestBufferForWriteData(int resiveData)
        {
            byte[] buffer = null;

            if (this.type == Utils.INT16)
            {
                Int16 data = Convert.ToInt16(resiveData);
                buffer = BitConverter.GetBytes(data);
            }
            else if (this.type == Utils.INT32)
            {
                buffer = BitConverter.GetBytes(resiveData);
            }
            else if (this.type == Utils.SINGLE)
            {
                Single data = Convert.ToSingle(resiveData);
                buffer = BitConverter.GetBytes(data);
            }
            else if (this.type == Utils.DOUBLE)
            {
                Double data = Convert.ToDouble(resiveData);
                buffer = BitConverter.GetBytes(data);
            }

            byte[] reverseBuffer = ConvertModbusData.reversBuffer(buffer);

            byte dataLenght = (byte) (requestBuffer[5]*2);

            byte[] writeBuffer = new byte[7 + dataLenght]; 

            writeBuffer[0] = requestBuffer[0];
            writeBuffer[1] = 16;
            writeBuffer[2] = requestBuffer[2];
            writeBuffer[3] = requestBuffer[3];
            writeBuffer[4] = requestBuffer[4];
            writeBuffer[5] = requestBuffer[5];
            writeBuffer[6] = dataLenght;

            //byte[] finishBuffer = new byte[buffer.Length + writeBuffer.Length];
          

            Console.WriteLine("writeBuffer.Length " + writeBuffer.Length);
            Console.WriteLine("buffer.Length " + buffer.Length);
           

          
           for(int i = 0; i < reverseBuffer.Length; i++)
            {
                writeBuffer[7 + i] = reverseBuffer[i];
            }
            
            return writeBuffer;
        }

    }
}
