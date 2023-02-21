
using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS.Nodes
{
    public class TRM210Node : Node
    {

        List<Item> paramsList = new List<Item>();

        public Item temp;
        public Item SPtemp;
        public Item power;
        public Item modePidOff;
        public Item P;
        public Item I;
        public Item D;
        public Item outPowerMin;
        public Item outPowerMax;

       



        public TRM210Node(byte adress)
        {           

            this.adress = adress;

            temp = new Item(new byte[] { adress, 3, 0, 1, 0, 1 }, Utils.INT16);
            temp.SuccessNotify += TRM210Model.updateTemperature;
            temp.FailureNotify += TRM210Model.failureTemperature;


            SPtemp = new Item(new byte[] { adress, 3, 0, 2, 0, 1 }, Utils.INT16);
            SPtemp.SuccessNotify += TRM210Model.updateSP;
            SPtemp.FailureNotify += TRM210Model.failureSP;

            power = new Item(new byte[] { adress, 3, 0, 4, 0, 1 }, Utils.INT16);
            power.SuccessNotify += TRM210Model.updatePower;
            power.FailureNotify += TRM210Model.failurePower;

            modePidOff = new Item(new byte[] { adress, 3, 0x3, 0x3, 0, 1 }, Utils.INT16);
            modePidOff.SuccessNotify += TRM210Model.updateModePid;
            modePidOff.FailureNotify += TRM210Model.failureModePid;

            paramsList.Add(temp);
            paramsList.Add(SPtemp);
            paramsList.Add(power);
            paramsList.Add(modePidOff);

        }

        public override void parseResponse(byte register, byte[] buffer, bool success)
        {
            Item paramItem = paramsList.Find((item) => item.register == register);

            if (paramItem != null)
            {
                if (success)
                {           
                    paramItem.setData(buffer);
                }
                else
                {
                    paramItem.cleanData();
                }

            }
        }
    }
}
