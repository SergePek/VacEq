using Program.MODBUS;

using Program.MODBUS.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form1 : Form
    {

        ModbusMaster modbusMaster;
        Thread modbusThread;
        

        public Form1()
        {
            InitializeComponent();
           
        }
      

       

        private void Form1_Load(object sender, EventArgs e)
        {


           modbusMaster = new ModbusMaster();

            //ModbusSlaves.initializeSlaves();

            ModbusNodes.initializeSlaves();

            modbusThread = new Thread(new ThreadStart(oprosSlaves));
            modbusThread.IsBackground = true;
            modbusThread.Start();
        }

        private void oprosSlaves()
        {
           
            while (true)
            {
                modbusMaster.oprosSlaves();
                Thread.Sleep(15);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label11.Text = modbusMaster.count.ToString();
            //byte[] databuffer = new byte[6];
            //databuffer[0] = 20;
            //databuffer[1] = 0x03;
            //databuffer[2] = 0x00;
            //databuffer[3] = 0x01;
            //databuffer[4] = 0x00;
            //databuffer[5] = 0x01;

            //modbusMaster.addRequest(databuffer);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] databuffer = new byte[6];
            databuffer[0] = 20;
            databuffer[1] = 0x03;
            databuffer[2] = 0x00;
            databuffer[3] = 0x01;
            databuffer[4] = 0x00;
            databuffer[5] = 0x01;

            modbusMaster.addRequest(databuffer);

            byte[] dataBuffer1 = new byte[6];
            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 3;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);


            byte[] databuffer2 = new byte[6];
            databuffer2[0] = 20;
            databuffer2[1] = 0x03;
            databuffer2[2] = 0x00;
            databuffer2[3] = 0x01;
            databuffer2[4] = 0x00;
            databuffer2[5] = 0x01;

            modbusMaster.addRequest(databuffer2);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 40;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 2;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x03;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x02;

            modbusMaster.addRequest(dataBuffer1);

            dataBuffer1[0] = 20;
            dataBuffer1[1] = 0x03;
            dataBuffer1[2] = 0x00;
            dataBuffer1[3] = 0x01;
            dataBuffer1[4] = 0x00;
            dataBuffer1[5] = 0x01;

            modbusMaster.addRequest(dataBuffer1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            modbusMaster.writeData(ModbusNodes.VacumNatekNode.setRashod.getReguestBufferForWriteData(345));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ModbusNodes.TRM210.temp.SuccessNotify += (d) => label14.Text = "Отл";

           // modbusMaster.addRequest(ModbusNodes.TRM210.temp.requestBuffer);

          


            //byte[] dataBuffer1 = new byte[9];

            //dataBuffer1[0] = 20;
            //dataBuffer1[1] = 0x10;
            //dataBuffer1[2] = 0x00;
            //dataBuffer1[3] = 0x02;
            //dataBuffer1[4] = 0x00;
            //dataBuffer1[5] = 0x01;
            //dataBuffer1[6] = 0x02;
            //dataBuffer1[7] = 0x00;
            //dataBuffer1[8] = 250;

            //modbusMaster.writeData(dataBuffer1);

            modbusMaster.writeData(ModbusNodes.TRM210.SPtemp.getReguestBufferForWriteData(1500));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //byte[] dataBuffer1 = new byte[6];
            //dataBuffer1[0] = 20;
            //dataBuffer1[1] = 0x03;
            //dataBuffer1[2] = 0x00;
            //dataBuffer1[3] = 0x04;
            //dataBuffer1[4] = 0x00;
            //dataBuffer1[5] = 0x01;

            //modbusMaster.addRequest(dataBuffer1);

            //modbusMaster.addRequest(ModbusNodes.TRM210.power.requestBuffer);
            modbusMaster.addRequest(ModbusNodes.TRM210.modePidOff.requestBuffer);
            //modbusMaster.writeData(ModbusNodes.TRM210.modePidOff.getReguestBufferForWriteData(1));
        }
    }
}
