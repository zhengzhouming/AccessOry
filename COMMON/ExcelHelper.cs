using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COMMON
{
   public class ExcelHelper : IDisposable
    {
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private IWorkbook workbook1 = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <param name="headno">要跳过的行</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, int headno)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    //  int i = workbook.NumberOfSheets;////获取个数
                    //    string sheetname = workbook.GetSheetName(0);//获取名字
                    //sheet = workbook.GetSheetAt(0); //获取指定的那一个
                    //  MessageBox.Show(i.ToString());
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }

                if (headno != 0)
                {
                    startRow = sheet.FirstRowNum + headno;//第一行
                }
                else
                {
                    startRow = sheet.FirstRowNum + 1;
                }

                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum;//获得行数
                    int maxcellCount = 0;//最大列数量
                    int maxcellno = 0;//最大列的行号
                    for (int r = 0; r < rowCount; ++r) //计算下一行的数据  取多列的行的数据生成列
                    {
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null)
                            {
                                continue; //没有数据的行默认是null　　 continue 结束单次循环　　　　　
                            }
                            //  IRow firstRow = sheet.GetRow(r);
                            int cellCount = row.LastCellNum; //一行最后一个cell的编号 这一行的总的列数

                            if (cellCount > maxcellCount)
                            {
                                maxcellCount = cellCount;//最大列数
                                //这一列的行号
                                maxcellno = i;
                            }
                        }//for (int i = startRow; i <= rowCount; ++i)
                    }
                    IRow firstRow = sheet.GetRow(maxcellno);
                    //   int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    //  bool isFirstRowColumn = true;
                    //  }
                    //  if (isFirstRowColumn)
                    // {
                    for (int i = firstRow.FirstCellNum; i < maxcellCount; ++i)
                    {
                        //名为“XX”的列已属于此 DataTable 的錯誤,資料一樣就會出錯---Excel 20170719
                        //      DataColumn column = new DataColumn(i.ToString());
                        //    data.Columns.Add(column);

                        ICell cell = firstRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = Convert.ToString(cell);

                            //   string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }//for (int i = firstRow.FirstCellNum; i < maxcellCount; ++i)

                    //最后一列的标号
                    //int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.Cells.Count == 0)
                        {
                            continue; //没有数据的行默认是null　　 continue 结束单次循环　　　　　
                        }
                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < maxcellCount; ++j)
                        {
                            //   if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            //   dataRow[j] = row.GetCell(j).ToString();
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                string va = row.GetCell(j).ToString();
                                // MessageBox.Show(va);
                                dataRow[j] = va;
                                //   dataRow[j] = row.GetCell(j).ToString();/////报错
                            }
                            // dataRow[j] = Convert.ToString( row.GetCell(j));/////报错
                        }//一列的值

                        data.Rows.Add(dataRow);
                    }// for (int i = startRow; i <= rowCount; ++i)
                }//for (int r = 0; r < rowCount; ++r)

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true)
        {
            //定义要返回的datatable对象
            DataTable data = new DataTable();
            //excel工作表
            ISheet sheet = null;
            //数据开始行(排除标题行)
            int startRow = 0;

            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }
                //根据指定路径读取文件
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook1 = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook1 = new HSSFWorkbook(fs);

                //根据文件流创建excel数据结构
                //           Npoi.SS.UserModel.IWorkbook workbook = Npoi.SS.UserModel.WorkbookFactory.Create(fs);
                //IWorkbook workbook = new HSSFWorkbook(fs);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook1.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook1.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook1.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    //Npoi.SS.UserModel.IRow firstRow = sheet.GetRow(0);
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //如果第一行是标题列名
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            //    Npoi.SS.UserModel.ICell cell = firstRow.GetCell(i);
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        //           Npoi.SS.UserModel.IRow row = sheet.GetRow(i);
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

        public string[] getExcelSheetName(string sheetName)
        {
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);
                // sheet = workbook.GetSheet(sheetName);
                int i = workbook.NumberOfSheets;////获取个数
                                                //    string sheetname = workbook.GetSheetName(0);//获取名字

                string[] sheetname = new string[i];//表名
                for (int t = 0; t < i; t++)
                {
                    sheetname[t] = workbook.GetSheetName(t);
                    // sheetname[t] = workbook.GetSheetName(t);
                }

                return sheetname;
                //  return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Console.WriteLine("Exception: " + ex.Message);
                string[] sheetname = { "未找到表名" };
                return sheetname;
            }
        }

        //public string getExcelSheetName(int sheetNo)
        //{
        //    try
        //    {
        //        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //        if (fileName.IndexOf(".xlsx") > 0) // 2007版本
        //            workbook = new XSSFWorkbook(fs);
        //        else if (fileName.IndexOf(".xls") > 0) // 2003版本
        //            workbook = new HSSFWorkbook(fs);
        //        // sheet = workbook.GetSheet(sheetName);
        //        string sheetname = workbook.GetSheetName(0);////获取个数
        //                                        //    string sheetname = workbook.GetSheetName(0);//获取名字
        //        return sheetname;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        // Console.WriteLine("Exception: " + ex.Message);
        //        return "";
        //    }
        //}
    
}
}
