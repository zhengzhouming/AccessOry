using COMMON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WinForm
{
     public class NPOIExcelHelper
    {
        //static void PrintData(DataTable data)
        //{
        //    if (data == null) return;
        //    for (int i = 0; i < data.Rows.Count; ++i)
        //    {
        //        for (int j = 0; j < data.Columns.Count; ++j)
        //            Console.Write("{0} ", data.Rows[i][j]);
        //        Console.Write("\n");
        //    }
        //}

        //写入EXCEL表  导出
        public void ExcelWrite(string file, DataTable tabl)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(file))
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

        //读EXCEL   导入EXCEL表
        //public void ExcelRead(string file)
        //{
        //    try
        //    {
        //        using (ExcelHelper excelHelper = new ExcelHelper(file))
        //        {
        //            DataTable dt = excelHelper.ExcelToDataTable("MySheet", true);
        //            //   PrintData(dt);//显示出来

        //            if (dt.Rows.Count <= 0)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                //要显示的文件的model 例emp
        //                empExporExcelModel[] depts = new empExporExcelModel[dt.Rows.Count];
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    depts[i] = ToModel(dt.Rows[i]);//这里转换过来
        //                }
        //                // return depts;
        //                ImportExcel IExcel = new ImportExcel();
        //                IExcel.IExcel.ItemsSource = depts;
        //                IExcel.ShowDialog();
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //    }
        //}

        //private empExporExcelModel ToModel(DataRow row)//建立要导入的文件的model
        //{
        //    empExporExcelModel deptss = new empExporExcelModel();
        //    for (int i = 0; i < row.ItemArray.Length; i++)
        //    {
        //        // deptss.name = Convert.ToInt32(row.ItemArray[0]);
        //        deptss.name = row.ItemArray[0].ToString();
        //        deptss.num = row.ItemArray[1].ToString();
        //        deptss.indata = row.ItemArray[2].ToString();
        //        deptss.sdf = row.ItemArray[3].ToString();
        //        deptss.yzk = row.ItemArray[4].ToString();
        //        //
        //    }
        //    return deptss;
        //}

        //static void Main(string[] args)
        //{
        //    string file = "..\\..\\myTest.xlsx";
        //    TestExcelWrite(file);
        //    TestExcelRead(file);
        //}
    }
}
