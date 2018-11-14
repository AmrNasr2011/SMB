using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB
{
    class ToExcelC
    {
        static public Microsoft.Office.Interop.Excel.Application excelApp;
        static public Microsoft.Office.Interop.Excel.Workbook currentWorkbook;
        static public Microsoft.Office.Interop.Excel.Worksheet currentWorksheet;
        static public int rowcounts = 2;
        public void export(DataTable data, string loc)
        {
            if (Excel_interface.currentWorksheet != null)
            {
                try
                {
                    currentWorksheet = Excel_interface.currentWorksheet;
                    currentWorkbook = Excel_interface.currentWorkbook;
                    excelApp = Excel_interface.excelApp;
                    excelApp.ActiveWindow.Activate();
                    rowcounts = Excel_interface.index;

                }
                catch (Exception)
                {
                    Excel_interface.currentWorksheet = null;
                    rowcounts = 2;
                    Excel_interface.excelApp.Quit();
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                    currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                    excelApp.Visible = true;
                    currentWorksheet.Cells[1, 1] = "L";
                    currentWorksheet.Cells[1, 2] = "Reference";
                    currentWorksheet.Cells[1, 3] = "Description";
                    currentWorksheet.Cells[1, 4] = "Quantity";
                    try
                    {
                        currentWorksheet.Columns[1].ColumnWidth = 10;
                    }
                    catch (Exception)
                    {
                    }
                }
             
            }
            else
            {
                if (currentWorksheet==null )//new one opened
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                    currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                    excelApp.Visible = true;
                    rowcounts = 2;
                    currentWorksheet.Cells[1, 1] = "L";
                    currentWorksheet.Cells[1, 2] = "Reference";
                    currentWorksheet.Cells[1, 3] = "Description";
                    currentWorksheet.Cells[1, 4] = "Quantity";
                    try
                    {
                        currentWorksheet.Columns[1].ColumnWidth = 10;
                    }
                    catch (Exception)
                    {                        
                    }
                }
                else
                {//check current excel is working fine
                    try
                    {
                        currentWorksheet.Columns[1].ColumnWidth = 10;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            excelApp.Quit();
                        }
                        catch (Exception)
                        { }

                        excelApp = new Microsoft.Office.Interop.Excel.Application();
                        currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                        currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                        excelApp.Visible = true;
                        rowcounts = 2;
                        currentWorksheet.Cells[1, 1] = "L";
                        currentWorksheet.Cells[1, 2] = "Reference";
                        currentWorksheet.Cells[1, 3] = "Description";
                        currentWorksheet.Cells[1, 4] = "Quantity";
                    }
                }

            }

            try
            {
                excelApp.ActiveWindow.Activate();
                //add data to excell
                excelApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized;
                excelApp.Visible = true;
                excelApp.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlNormal;
                excelApp.Height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
                excelApp.Width = 450;
                excelApp.Top = 0;
                excelApp.Left = System.Windows.Forms.SystemInformation.VirtualScreen.Width - 800;
                foreach (DataRow row in data.Rows)
                {

                    currentWorksheet.Cells[rowcounts, 3] = row["Description"].ToString();
                    currentWorksheet.Cells[rowcounts, 2] = row["Reference"].ToString();
                    currentWorksheet.Cells[rowcounts, 1] = "L";
                    currentWorksheet.Cells[rowcounts, 4] = row["Quantity"].ToString();
                    rowcounts = rowcounts + 1;

                }
                Excel_interface.index = rowcounts;
            }
            catch (Exception)
            {
                rowcounts = 2;
                excelApp = null;

            }


            //Adjust Format for excel file (case of normal add)

            formatExcel(currentWorksheet);


            //try
            //{
            //    if (loc != "")
            //    {
            //        excelApp.Visible = true;
            //        currentWorkbook.SaveAs(loc, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing, Type.Missing);
            //        currentWorkbook.Saved = true;
            //    }
            //    else
            //    {
            //        excelApp.Quit();
            //    }

            //}
            //catch (Exception)
            //{

            //    System.Windows.Forms.MessageBox.Show("File not saved");
            //}

        }
     


        //public void DataTabe_to_Excel(DataTable table, string table_name)
        // {
        //     Microsoft.Office.Interop.Excel._Application excelApp = null;
        //     Microsoft.Office.Interop.Excel.Workbook currentWorkbook = null;
        //     Microsoft.Office.Interop.Excel.Worksheet currentWorksheet;
        //     try
        //     {
        //         excelApp = new Microsoft.Office.Interop.Excel._Application();
        //         currentWorkbook = excelApp.Workbooks.Add(Type.Missing);

        //         //add data to excell


        //         currentWorksheet= currentWorkbook.Worksheets.Add(table, table_name);
        //         currentWorksheet.Activate();
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // } 



        public void ExportToExcel(DataTable DataTable, string sheet_name = "sheet1", string ExcelFilePath = null)
        {
            try
            {
                int ColumnsCount;

                if (DataTable == null || (ColumnsCount = DataTable.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                Microsoft.Office.Interop.Excel._Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet Worksheet = Excel.ActiveSheet;
                Worksheet.Name = sheet_name;
                object[] Header = new object[ColumnsCount];

                // column headings               
                for (int i = 0; i < ColumnsCount; i++)
                    Header[i] = DataTable.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[1, ColumnsCount]));
                HeaderRange.Value = Header;
                HeaderRange.Interior.ColorIndex = 50;
                HeaderRange.Font.ColorIndex = 2;
                HeaderRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                HeaderRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                HeaderRange.Font.Bold = true;
               

                // DataCells
                int RowsCount = DataTable.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = DataTable.Rows[j][i];

                Worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[2, 1]), (Microsoft.Office.Interop.Excel.Range)(Worksheet.Cells[RowsCount + 1, ColumnsCount])).Value = Cells;

                // check fielpath
                if (ExcelFilePath != null && ExcelFilePath != "")
                {
                    try
                    {
                        Worksheet.SaveAs(ExcelFilePath);
                        Excel.Quit();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                else    // no filepath is given
                {
                    Excel.Visible = true;
                }
                Worksheet.UsedRange.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
            
        }
        void formatExcel(Microsoft.Office.Interop.Excel.Worksheet currentWorksheet1)
        {
            try
            {
                currentWorksheet1.Cells[1, 1].EntireRow.Font.Bold = true;
                currentWorksheet1.Cells[1, 1].EntireRow.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentWorksheet1.Cells[1, 1].EntireRow.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentWorksheet1.Cells[1, 1].EntireRow.RowHeight = 31;
                currentWorksheet.Cells[1, 1].EntireColumn.ColumnWidth = 3;
                currentWorksheet.Cells[1, 2].EntireColumn.ColumnWidth = 16;
                currentWorksheet.Cells[1, 3].EntireColumn.ColumnWidth = 47.5;
                currentWorksheet.Cells[1, 4].EntireColumn.ColumnWidth = 8.5;

                currentWorksheet.Cells[1, 1].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentWorksheet.Cells[1, 2].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentWorksheet.Cells[1, 3].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                currentWorksheet.Cells[1, 4].EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                currentWorksheet.Cells[1, 1].Interior.ColorIndex = 50;
                currentWorksheet.Cells[1, 2].Interior.ColorIndex = 50;
                currentWorksheet.Cells[1, 3].Interior.ColorIndex = 50;
                currentWorksheet.Cells[1, 4].Interior.ColorIndex = 50;

                currentWorksheet.Cells[1, 1].Font.ColorIndex = 2;
                currentWorksheet.Cells[1, 2].Font.ColorIndex = 2;
                currentWorksheet.Cells[1, 3].Font.ColorIndex = 2;
                currentWorksheet.Cells[1, 4].Font.ColorIndex = 2;
            }
            catch (Exception)
            {

            }

        }
    }
}
