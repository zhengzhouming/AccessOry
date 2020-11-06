using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class sizeRunManager
    {
        sizeRunService sizeS = new sizeRunService();
        public DataTable getSizeRunByMy_no(string my_no)
        {
            return sizeS.getSizeRunByMy_no(my_no);
          
        }
        public DataTable getClr_noByMy_no(string my_no)
        {
            return sizeS.getClr_noByMy_no(my_no);

        }
        public DataTable getSizeByMy_no(string my_no)
        {
            return sizeS.getSizeByMy_no(my_no);

        }

        public DataTable getAllSizeRunByMy_no(string my_no)
        {
            return sizeS.getAllSizeRunByMy_no(my_no);

        }
    }
}
