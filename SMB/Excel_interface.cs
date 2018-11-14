using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace SMB
{
    class Excel_interface
    {
        static public Microsoft.Office.Interop.Excel.Application excelApp;
        static public Microsoft.Office.Interop.Excel.Workbook currentWorkbook;
        static public Microsoft.Office.Interop.Excel.Worksheet currentWorksheet;
        static public int index = 2;
        static public void startNewExcel()
        {
            if (ToExcelC.currentWorksheet != null)
            {
                try
                {
                    excelApp = ToExcelC.excelApp;
                    currentWorkbook = ToExcelC.currentWorkbook;
                    currentWorksheet = ToExcelC.currentWorksheet;
                    currentWorksheet.Columns.ColumnWidth = 18;
                    index = ToExcelC.rowcounts;
                }
                catch (Exception)
                {
                    try
                    {
                        excelApp.Quit();

                    }
                    catch (Exception)
                    {}
                    ToExcelC.currentWorksheet = null;
                    index = 2;
                    excelApp = null;
                    try
                    {
                        excelApp = new Microsoft.Office.Interop.Excel.Application();
                        currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                        currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                        excelApp.Visible = true;
                        excelApp.Height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
                        excelApp.Width = 450;
                        excelApp.Top = 0;
                        excelApp.Left = System.Windows.Forms.SystemInformation.VirtualScreen.Width - 800;
                    }
                    catch (Exception ex)
                    {

                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
               
            }
            else
            {
                index = 2;
                excelApp = null;
                try
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();
                    currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                    currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                    excelApp.Visible = true;
                    excelApp.Height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
                    excelApp.Width = 450;
                    excelApp.Top = 0;
                    excelApp.Left = System.Windows.Forms.SystemInformation.VirtualScreen.Width - 800;
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }


        }
        public void Add_new_line(List<string> description, string refernce, string quantity)
        {
            string aggregate_des;
            if (refernce == "")
            {
                return;
            }
            
            try
            {
                if (index == 2)
                {
                    startNewExcel();
                    currentWorksheet.Cells[1, 1] = "L";
                    currentWorksheet.Cells[1, 2] = "Refernce";
                    currentWorksheet.Cells[1, 4] = "Quantity";
                    currentWorksheet.Cells[1, 3] = "Description";
                    
                }

               
            }
            catch (Exception)
            {
                index = 2;
                try
                {
                    excelApp.Quit();
                }
                catch (Exception)
                { }

                startNewExcel();
                currentWorksheet.Cells[1, 1] = "L";
                currentWorksheet.Cells[1, 2] = "Reference";
                currentWorksheet.Cells[1, 3] = "Description";
                currentWorksheet.Cells[1, 4] = "Quantity";
            }
           
            aggregate_des = string.Join(",", description.ToArray());
            try
            {
                // instantiating the excel application class


                
                excelApp.WindowState = XlWindowState.xlMinimized;
                excelApp.Visible = true;
                excelApp.WindowState = XlWindowState.xlNormal;
                excelApp.Height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
                excelApp.Width = 450;
                excelApp.Top = 0;
                excelApp.Left = System.Windows.Forms.SystemInformation.VirtualScreen.Width - 800;
                currentWorksheet.Cells[index, 1] = "L";
                currentWorksheet.Cells[index, 2] = refernce;
                currentWorksheet.Cells[index, 4] = quantity;
                currentWorksheet.Cells[index, 3] = aggregate_des;
                index++;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                index = 2;
                try
                {
                    excelApp.Quit();
                }
                catch (Exception)
                { }
                excelApp = null;
            }
            finally
            {

            }
            formatExcel(currentWorksheet);
        }
        public void Add_new_Comment(string comment)
        {

            if (index == 2)
            {
                try
                {
                    startNewExcel();
                    currentWorksheet.Cells[1, 1] = "L";
                    currentWorksheet.Cells[1, 2] = "Refernce";
                    currentWorksheet.Cells[1, 4] = "Quantity";
                    currentWorksheet.Cells[1, 3] = "Description";
                    currentWorksheet.Columns.ColumnWidth = 18;
                }
                catch (Exception)
                {

                }
            }

            excelApp.Visible = true;
            try
            {
                // instantiating the excel application class


                //excelApp.Visible = true;
                currentWorksheet.Cells[index, 1] = "T";
                currentWorksheet.Cells[index, 2] = "*****";
                currentWorksheet.Cells[index, 4] = "*****";
                currentWorksheet.Cells[index, 3] = comment;
                index++;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

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
