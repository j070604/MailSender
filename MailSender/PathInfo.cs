using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSender
{
    class PathInfo
    {
        static public String GetHosFolderPath(String defaultFolder=null)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //string defaultFolder = @"\\Fileserver1\TechHeim\TH\병원";
            if (Directory.Exists(defaultFolder))
                folderDialog.SelectedPath = defaultFolder;

            DialogResult result;
            DialogResult mBoxResult;

            do
            {
                result = folderDialog.ShowDialog();
                if (result == DialogResult.OK)
                    return folderDialog.SelectedPath;
                else
                {
                    mBoxResult = MessageBox.Show("엑셀파일이 정상적으로 선택되지 않았습니다." + Environment.NewLine + "다시 선택하시겠습니까?",
                                    "", MessageBoxButtons.YesNo);
                }
            } while (DialogResult.Yes == mBoxResult);

            return null;
        }

        static public String GetExFilePath(String defaultFolder = null)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            //String defaultFolder = @"\\fileserver1\기술지원부\05_PS Team\유지보수 월별통계";
            if (Directory.Exists(defaultFolder))
                openFile.InitialDirectory = defaultFolder;

            openFile.DefaultExt = "xlsx";

            DialogResult result;
            DialogResult mBoxResult;
            do
            {
                result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                    return openFile.FileName;
                else
                {
                    mBoxResult = MessageBox.Show("엑셀파일이 정상적으로 선택되지 않았습니다." + Environment.NewLine + "다시 선택하시겠습니까?",
                                    "", MessageBoxButtons.YesNo);
                }
            } while(DialogResult.Yes == mBoxResult);

            return null;
        }
    }
}
