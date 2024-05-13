using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUL
{
    public class BUL_BangThamSo
    {
        private DAL.DAL_BangThamSo _dalAgurment;
        public BUL_BangThamSo()
        {
            _dalAgurment = new DAL.DAL_BangThamSo();
        }

        public void updateAgurment(string agurment, double value)
        {
            _dalAgurment.UpdateAgurmentValue(agurment, value);
        }
        public List<DTO.BANGTHAMSO> getAllAgurment()
        {
            return _dalAgurment.getAllAgurment();
        }

        public double getValueByArgument(string argument)
        {
            return _dalAgurment.getValueByArgument(argument);
        }
    }
}
