using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.MODBUS.Nodes
{
    public abstract class Node
    {
        public byte adress;

        public abstract void parseResponse(byte register, byte[] buffer, bool success);
       
    }
}
