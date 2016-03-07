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
        public ~ExcelAccess()
        {

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
            return true;
        }

        public Array GetRange(String range1, String range2)
        {
            return null;
        }
    }
}
