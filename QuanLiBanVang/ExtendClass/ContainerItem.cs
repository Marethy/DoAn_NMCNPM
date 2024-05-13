using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.ExtendClass
{
    public class ContainerItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
