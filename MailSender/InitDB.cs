using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MailSender
{
    public partial class InitDB : Form
    {
        List<String> folderList;
        List<String> excelList;

        String exFilePath;
        String folderPath;

        DBHandler dbhandler;

        public InitDB()
        {
            InitializeComponent();
        }

        private void InitDB_Load(object sender, EventArgs e)
        {
            dbhandler = DBHandler.GetInstance();

            excelList = new List<String>();
            exFilePath = GetExFilePath();
            InitHospitalList(excelList, exFilePath); // 엑셀에서 병원 리스트를 가져온다

            folderList = new List<String>();
            folderPath = GetHosFolderPath();
            InitFolderList(folderList, folderPath);  //파일서버에서 폴더 리스트를 가져온다.
           
            //매칭시작 

            Matching();
        }
        /**/

        private void InitFolderList(List<String> folderList, String folderPath)
        {
            System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(folderPath);
            if (Info.Exists)
            {
                System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.DirectoryInfo info in CInfo)
                {
                    folderList.Add(info.Name);
                }
            }
        }

        private String GetHosFolderPath()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            string defaultFolder = @"\\Fileserver1\TechHeim\TH\병원";
            if (Directory.Exists(defaultFolder))
                folderDialog.SelectedPath = defaultFolder;

            folderDialog.ShowDialog();

            return folderDialog.SelectedPath;
        }

        private String GetExFilePath()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            String defaultFolder = @"\\fileserver1\기술지원부\05_PS Team\유지보수 월별통계";
            if (Directory.Exists(defaultFolder))
                openFile.InitialDirectory = defaultFolder;

            openFile.DefaultExt = "xlsx";
          
            do
            {
                openFile.ShowDialog();
                if (openFile.FileNames.Length == 1)
                {
                    foreach (string filename in openFile.FileNames)
                        return filename;
                }
                else
                {
                    MessageBox.Show("하나의 엑셀 파일을 선택하세요.");
                }
            } while (openFile.FileNames.Length != 1);

            return null;
        }

        private void InitHospitalList(List<String> excelList, String exFilePath)//병원정보 있는 엑셀파일이랑 메일정보 있는 엑셀파일이랑 2개가 있음.
        {
            Array exData;

            using (ExcelAccess servCheck = new ExcelAccess(exFilePath, "aaaaaaaaa"))
            {
                servCheck.SelectSheet("병원");
                exData = servCheck.GetRange("E2", "G295");
                ConvertArrayToList(excelList, exData); //그냥 array 값을 수동으로 읽어와서 반복문에서 하나하나 입력해 주는게 나을 것 같다.
            }
            //return ConvertArrayToList(exData);
        }

        private List<String> ConvertArrayToList(Array array)
        {
            const int arrayWidth = 3;
            List<String> excelList = new List<String>();
            for (int i = 1; i <= array.Length / arrayWidth; i++)
            {
                if (array.GetValue(i, 1) == null)
                    continue;
                if ((String)array.GetValue(i, 3) == "매월")
                    continue;
                else
                    excelList.Add(array.GetValue(i, 1).ToString());
            }
            return excelList;
        }

        private void ConvertArrayToList(List<String> excelList, Array array)
        {
            const int arrayWidth = 3;

            for (int i = 1; i <= array.Length / arrayWidth; i++)
            {
                if (array.GetValue(i, 1) == null)
                    continue;
                if ((String)array.GetValue(i, 3) == "매월")
                    continue;
                else
                    excelList.Add(array.GetValue(i, 1).ToString());
            }
        }

        private string GetFolderList(List<String> hosFolderList)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            string fsRootFolder = @"\\Fileserver1\TechHeim\TH\병원";
            if (Directory.Exists(fsRootFolder))
                folderDialog.SelectedPath = fsRootFolder;

            folderDialog.ShowDialog();
            string path = folderDialog.SelectedPath;
            System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(path);
            if (Info.Exists)
            {
                System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.DirectoryInfo info in CInfo)
                {
                    hosFolderList.Add(info.Name);
                }
            }
            return path;
        }

        private void Matching()
        {
            listView1.Items.Clear();
            ListViewItem lvi;

            String exHosName = excelList.First();
            if (exHosName == null)
            {
                tBoxMsg.Text = "excleList is empty";
                return;
            }

            for (int i = 0; i < folderList.Count; i++)
            {
                if(isSimilar(exHosName, folderList[i]))
                {
                    lvi = new ListViewItem(exHosName);
                    lvi.SubItems.Add(folderList[i]);
                    String fileFormat = GetFileFormat(folderList[i]);
                    lvi.SubItems.Add(fileFormat);
                    listView1.Items.Insert(0, lvi);
                }
            }

            /*
             * 1. 엑셀리스트에서 하나 가져온다.
             * 2. 폴더리스트의 목록에서 반복하여 유사한 폴더일 경우 listview에 등록한다.
             * 2.1 폴더 안을 탐색하여 파일 포멧까지 가져온다.
             * 3 - 1. listview에 등록된 목록이 1개면 그대로 등록한다.
             * 3 - 2. listview에 등록된 목록이 0 or 2개이상이면 사용자에게 입력을 받는다.
             * 3 - 3.
             */
            if(listView1.Items.Count ==1)
            {
                //save info the DB
                //remove firstexcellist
                dbhandler.InsertHospital(new HospitalData(listView1.Items[0].SubItems[0].Text, listView1.Items[0].SubItems[1].Text, listView1.Items[0].SubItems[2].Text, folderPath));
                excelList.RemoveAt(0);
                Matching();
            }
        }
        private String GetFileFormat(String folderPath)
        {
            String folderFullPath = this.folderPath + "\\" + folderPath;
            string[] files = Directory.GetFiles(folderFullPath).Select(path => Path.GetFileName(path)).ToArray(); // 예외처리 필요한가
            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (isValidFormat(files[i]))
                    return files[i].Replace("2016", "yyyy").Replace("2015", "yyyy").Replace("02", "mm").Replace("01", "mm").Replace("12", "mm");
            }
            return null;
        }

        private bool isValidFormat(string file)
        {
            bool flag = false;
            if (file.Contains("2015") && file.Contains("12"))
                flag = true;
            else if (file.Contains("2016") && file.Contains("01"))
                flag = true;
            else if (file.Contains("2016") && file.Contains("02"))
                flag = true;

            return flag;
        }

        private bool isSimilar(string hosName, string folderName)
        {
            int count = 0;
            int folderIndex = 0;

            for (int i = 0; i < hosName.Length; i++)
            {
                for (int j = folderIndex; j < folderName.Length; j++)
                {
                    if (hosName[i] == folderName[j])
                    {
                        count++;
                        folderIndex = j;
                        break;
                    }
                }
            }
            return (10 * count - 8 * hosName.Length > 0) ? true : false;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            excelList.RemoveAt(0);
            Matching();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            dbhandler.InsertHospital(new HospitalData(excelList.First(),tBoxFolderName.Text, tBoxFileFormat.Text, folderPath));
            excelList.RemoveAt(0);
            Matching();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            dbhandler.InsertHospital(new HospitalData(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, folderPath));
        }



    }
}
