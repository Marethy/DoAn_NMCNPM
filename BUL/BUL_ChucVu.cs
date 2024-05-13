using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_ChucVu
    {
        DAL.DAL_ChucVu _dalPosition;
        public BUL_ChucVu()
        {
            _dalPosition = new DAL.DAL_ChucVu();
        }
        public List<DTO.CHUCVU> getAllPosition()
        {
            return _dalPosition.getListPosition();
        }
        public DTO.CHUCVU getPositionById(int id)
        {
            return _dalPosition.getPositionById(id);
        }

    }
}
