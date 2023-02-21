using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS.Nodes
{
    static class ModbusNodes
    {
        static public List<Node> slaves = new List<Node>();

        static public TRM210Node TRM210;
        static public VacumNatekNode VacumNatekNode;

        static public void addSlave(Node modbusSlave)
        {
            slaves.Add(modbusSlave);
        }


        static public void parseResponse(byte[] sendBuffer, byte[] resiveBuffer)
        {
            bool success = (sendBuffer != resiveBuffer);
            //bool success = false;
           

            Node node = slaves.Find((item) => item.adress == sendBuffer[0]);
            
            if (node != null)
            {
                node.parseResponse(sendBuffer[3], resiveBuffer, success);
            }

        }

        public static void initializeSlaves()
        {
            TRM210 = new TRM210Node(20);
            VacumNatekNode = new VacumNatekNode(2);



            slaves.Add(TRM210);
            slaves.Add(VacumNatekNode);
        }

       
    }
}
