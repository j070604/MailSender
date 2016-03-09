using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MailSender
{
    class ExcelAccess : IDisposable
    {
        //하나의 ExcelAccess 객체가 1개의 엑셀 파일에 접근한다.
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Worksheet xlWriteSheet;

        String fileName;

        public ExcelAccess(String fileName)
        {
            OpenExcelFile(fileName);
        }

        public ExcelAccess()
        {

        }


        public bool OpenExcelFile(String fileName)
        {
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            this.fileName = fileName;
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

        /*
         * readonly, writeable
         * */
        public void Dispose()
        {
            xlWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlWorkBook.Close();
            xlApp.Quit();

            if (xlWorkSheet != null) { releaseObject(xlWorkSheet); }
            if (xlWorkBook != null) { releaseObject(xlWorkBook); }
            if (xlApp != null) { releaseObject(xlApp); }
        }
    }
}
