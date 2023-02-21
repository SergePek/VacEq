using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    static class ModbusCRC16
    {
        public static byte[] makeCRC16(byte[] buf)
        {
            ushort crc = 0xFFFF;
            int len = buf.Length;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= buf[pos];

                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);

            return ret;

            // byte[] rett = BitConverter.GetBytes((ushort)((crc >> 8) | (crc << 8)));
            //return rett;
        }

        public static byte[] addCRC16(byte[] dataBuffer)
        {

            byte[] crc = makeCRC16(dataBuffer);

            byte[] sendBuffer = new byte[dataBuffer.Length + 2];

            for (int i = 0; i < sendBuffer.Length; i++)
            {
                if (i < dataBuffer.Length)
                {
                    sendBuffer[i] = dataBuffer[i];
                }
            }
            sendBuffer[sendBuffer.Length - 2] = crc[0];
            sendBuffer[sendBuffer.Length - 1] = crc[1];

            //Console.WriteLine("Данные для отправки");
            //for (int i = 0; i < sendBuffer.Length; i++)
            //{
            //    Console.WriteLine(sendBuffer[i]);
            //}

            return sendBuffer;
        }

        public static bool checkCRC16(byte[] reciveBuffer)
        {
            if (reciveBuffer.Length < 2)
            {
                return false;
            }

            byte[] dataBuffer = new byte[reciveBuffer.Length - 2];
            byte[] reciveCRC = new byte[2];

            for (int i = 0; i < dataBuffer.Length; i++)
            {
                dataBuffer[i] = reciveBuffer[i];
            }

            reciveCRC[0] = reciveBuffer[reciveBuffer.Length - 2];
            reciveCRC[1] = reciveBuffer[reciveBuffer.Length - 1];

            byte[] crc = makeCRC16(dataBuffer);
            //Console.WriteLine("resiveCRC1: " + reciveCRC[0]);
            //Console.WriteLine("resiveCRC2: " + reciveCRC[1]);
            //Console.WriteLine("crc1 : " + crc[0]);
            //Console.WriteLine("crc2 : " + crc[1]);
            //Console.ReadKey();
            if (reciveCRC[0] == crc[0] && reciveCRC[1] == crc[1])
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
