using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS
{
    static class ConvertModbusData
    {
        public static Int16 convertToInt16(byte [] buffer)
        {
            return BitConverter.ToInt16(reversBuffer(buffer), 2);
        }

        public static Single convertToSingle(byte [] buffer)
        {
            return BitConverter.ToSingle(reversBuffer(buffer), 2);
        }

        public static byte [] reversBuffer(byte [] buffer)
        {
            int bufferSize = buffer.Length;

            byte[] bufferReverse = new byte[bufferSize];
            int j = 0;

            for (int i = bufferSize - 1; i >= 0; i--)
            {

                bufferReverse[j] = buffer[i];
                j++;
            }
            return bufferReverse;
        }

        public static int getRequestCountByte(byte [] buffer)
        {
        //    Console.Write("Отправка ");
        //    for (int i = 0; i < buffer.Length; i++)
        //    {
        //        Console.Write(buffer[i] + " ");
        //    }
        //    Console.WriteLine();

        //    Console.Write("Реверс   ");
        //    byte[] revers = reversBuffer(buffer);

        //    for (int i = 0; i < revers.Length; i++)
        //    {
        //        Console.Write(revers[i] + " ");
        //    }
        //    Console.WriteLine();


            return BitConverter.ToInt16(reversBuffer(buffer), 2) * 2; 
        }

        internal static double convertToDouble(byte[] buffer)
        {
            return BitConverter.ToDouble(reversBuffer(buffer), 2);
        }

        internal static int convertToInt32(byte[] buffer)
        {
            return BitConverter.ToInt32(reversBuffer(buffer), 2);
        }

        internal static int getWriteCountByte(byte[] writeBuffer)
        {
            return BitConverter.ToInt16(writeBuffer,6);
        }
    }
}
