using Program.MODBUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    static class VavummeterNatekatelModel
    {
        static Single vacum;
        static Single SPVacum;

        public static void updateVacum(byte[] data)
        {
            Console.Write("Вакуум = ");
            vacum = ConvertModbusData.convertToSingle(data);
            Console.WriteLine(vacum);
        }

        public static void failVacum()
        {
            Console.Write("Вакуум = ");
            vacum = Single.NaN;
            Console.WriteLine(vacum);
        }

        public static void updateSetVacum(byte[] data)
        {
            Console.WriteLine("Уставка вакуума прошла успешно");
           
        }

        public static void failSetVacum()
        {
            Console.WriteLine("Ошибка уставки вакуума");
           
        }
    }
}
