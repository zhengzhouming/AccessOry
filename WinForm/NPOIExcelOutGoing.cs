
using COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WinForm
{
    public class NPOIExcelOutGoing
    {
        public void ExcelWrite(string file, DataTable tabl)
        {
            try
            {
                

                using (ExcelOutGoing excelHelper = new ExcelOutGoing(file))
                {
                    int count = excelHelper.DataTableToExcel(tabl, "MySheet", true);
                    if (count > 0)
                        Console.WriteLine("Number of imported data is {0} ", count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
