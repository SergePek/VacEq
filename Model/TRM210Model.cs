using Program.MODBUS;
using Program.MODBUS.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    static class TRM210Model
    {
        
        static Single temperature;
        static Single sp;
        static Int16 power;
        static Int16 modePidOff;
        

        public static void updateTemperature(byte [] data)
        {
            Console.Write("Температура = ");
            temperature = Convert.ToSingle( ConvertModbusData.convertToInt16(data)) / 10;
            Console.WriteLine(temperature);
        }

        public static void failureTemperature()
        {
            Console.Write("Температура = ");
            temperature = Single.NaN;
            Console.WriteLine(temperature);
        }

        public static void updateSP(byte [] buffer)
        {
            Console.WriteLine("Уставка температуры прошла успешно");
             
        }

        public static void failureSP()
        {        
            Console.WriteLine("Не удалось установить температуру");
        }

        public static void updatePower(byte[] buffer)
        {
            Console.Write("Мощность = ");
            power = ConvertModbusData.convertToInt16(buffer);
            Console.WriteLine(power);
        }

        public static void failurePower()
        {
            Console.WriteLine("Не удалось получить мощность");
        }

        internal static void updateModePid(byte[] data)
        {
            modePidOff = ConvertModbusData.convertToInt16(data);
            Console.Write("Режим ПИД: ");
            Console.WriteLine(modePidOff);
        }

        internal static void failureModePid()
        {
            Console.WriteLine("Ошибка режим Пид");
        }
    }
}
