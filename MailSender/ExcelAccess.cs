using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MailSender
{
    class ExcelAccess
    {
        //하나의 ExcelAccess 객체가 1개의 엑셀 파일에 접근한다.
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Worksheet xlWriteSheet;

        public ExcelAccess(String fileName)
        {
            OpenExcelFile(fileName);
        }
        public ExcelAccess()
        {

        }

        ~ExcelAccess()
        {
            /*
             * 열려있는 엑셀 파일이 수정가능한지 아닌지 확인한 후에 저장후 release 또는 즉시 release 
             * */
//          string a = @"2016-03_점검통계.xlsx";
//            xlWorkBook.SaveAs(a, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
//            xlWorkBook.Close();
//            xlApp.Quit();

            if (xlWorkSheet != null) { releaseObject(xlWorkSheet); }
            if (xlWorkBook != null) { releaseObject(xlWorkBook); }
            if (xlApp != null) { releaseObject(xlApp); }
        }

        public bool OpenExcelFile(String fileName)
        {
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            return true;
        }

        public bool SelectSheet(String sheetName)
        {
            xlWorkSheet = xlWorkBook.Sheets[sheetName];

            return true;
        }

        public Array GetRange(String range1, String range2)
        {
            Excel.Range range = xlWorkSheet.get_Range(range1, range2);
            return (System.Array)range.Cells.Value2;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
