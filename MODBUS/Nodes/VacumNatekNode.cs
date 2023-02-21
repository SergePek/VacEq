using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS.Nodes
{
    public class VacumNatekNode : Node
    {

        List<Item> paramsList = new List<Item>();

        public Item vacum;

        public Item setRashod;



        public VacumNatekNode(byte adress)
        {
            this.adress = adress;

            vacum = new Item(new byte[] { adress, 3, 0, 3, 0, 2 }, Utils.SINGLE);
            vacum.SuccessNotify += VavummeterNatekatelModel.updateVacum;
            vacum.FailureNotify += VavummeterNatekatelModel.failVacum;


            setRashod = new Item(new byte[] { adress, 3, 0, 17, 0, 2 }, Utils.INT32);
            setRashod.SuccessNotify += VavummeterNatekatelModel.updateSetVacum;
            setRashod.FailureNotify += VavummeterNatekatelModel.failSetVacum;
          

            paramsList.Add(vacum);
            paramsList.Add(setRashod);
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
