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

        const int LISTVIEW_ROOF_START = 1;

        public InitDB()
        {
            InitializeComponent();
        }

        private void InitDB_Load(object sender, EventArgs e)
        {
            dbhandler = DBHandler.GetInstance();
            /*
            excelList = new List<String>();
            exFilePath = PathInfo.GetExFilePath(@"\\fileserver1\기술지원부\05_PS Team\유지보수 월별통계"); //GetExFilePath();
            InitHospitalList(excelList, exFilePath); // 엑셀에서 병원 리스트를 가져온다

            folderList = new List<String>();
            folderPath = PathInfo.GetHosFolderPath(@"\\Fileserver1\TechHeim\TH\병원"); //GetHosFolderPath();
            InitFolderList(folderList, folderPath);  //파일서버에서 폴더 리스트를 가져온다.
           
            //매칭시작 

            Matching();
            */

        }
        /**/

        private void InitFolderList(List<String> folderList, String folderPath)
        {
            System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(folderPath);
            if (Info.Exists)
            {
                System.IO.DirectoryInfo[] CInfo = Info.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly);
                foreach (System.IO.DirectoryInfo info in CInfo)
                    folderList.Add(info.Name);
            }
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
       
        private void Matching()
        {
            listView1.Items.Clear();
            ListViewItem lvi;

            String exHosName;
            try
            {
                exHosName = excelList.First();
            }
            catch
            {
                tBoxMsg.Text = "excleList is empty";
                return;
            }

            InsertDefaultItem(exHosName);

            for (int i = 0; i < folderList.Count; i++)
            {
                if(isSimilar(exHosName, folderList[i]))
                {
                    lvi = new ListViewItem(exHosName);
                    lvi.SubItems.Add(folderList[i]);
                    String fileFormat = GetFileFormat(folderList[i]);
                    lvi.SubItems.Add(fileFormat);
                    listView1.Items.Insert(listView1.Items.Count, lvi);
                }
            }
            InsertItem(); 
        }

        private void InsertDefaultItem(String exHosName)
        {
            ListViewItem lvi = new ListViewItem(exHosName);
            listView1.Items.Insert(0, lvi);
        }

        private void InsertItem()
        {
            const int FOLDER_NOT_FOUNT = 1;
            const int DEFAULT_INSERT_BY_FOLDERNUM = 2;
            const int DEFAULT_INSERT_BY_FORMATNUM = 1;
            const int INSERT_SELECT_NEED = 3;

            if (listView1.Items.Count == DEFAULT_INSERT_BY_FOLDERNUM)
            {
                const int DEFAULT_INSERT_INDEX = 1;
                InsertHospital(listView1.Items[DEFAULT_INSERT_INDEX]);
                Matching();
            }
            else if (CountFileFormat() == DEFAULT_INSERT_BY_FORMATNUM)
            {
                int index = GetFileFormatIndex();
                InsertHospital(listView1.Items[index]);
                Matching();
            }
            else if (listView1.Items.Count == FOLDER_NOT_FOUNT)
            {
                tBoxMsg.Text = listView1.Items[0].SubItems[0].Text + " 는 수동 입력이 필요합니다.";
            }
            else if (listView1.Items.Count >= INSERT_SELECT_NEED) //선택이 필요한 경우 HosName == FolderName 이면 그냥 Insert 한다.
            {
                for (int i = LISTVIEW_ROOF_START; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[0].Text.Equals(listView1.Items[i].SubItems[1].Text))
                    {
                        InsertHospital(listView1.Items[i]);
                        Matching();
                        break;
                    }
                }
            }  
        }

        private int GetFileFormatIndex()
        {
            const int formatColIndex = 2;

            for (int i = LISTVIEW_ROOF_START; i < listView1.Items.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(listView1.Items[i].SubItems[formatColIndex].Text))
                    return i;
            }
            return -1;
        }
        
        private int CountFileFormat()
        {
            int count = 0;
            const int formatColIndex = 2;
            for (int i = LISTVIEW_ROOF_START; i < listView1.Items.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(listView1.Items[i].SubItems[formatColIndex].Text))
                    ++count;
            }
            return count;
        }

        private String GetFileFormat(String folderPath)
        {
            String folderFullPath = this.folderPath + "\\" + folderPath;
            string [] files;
            try
            {
                files = Directory.GetFiles(folderFullPath).Select(path => Path.GetFileName(path)).ToArray(); // 예외처리 필요한가
            }
            catch
            {
                String BGSFolder = @"\\fileserver1\TechHeim\TH\보건소\";
                files = Directory.GetFiles(BGSFolder + folderPath).Select(path => Path.GetFileName(path)).ToArray();
            }
            
            for (int i = files.Length - 1; i >= 0; i--)
            {
                if (isValidFormat(files[i]))
                    return ReplaceStr(files[i]);
            }
            return null;
        }

        private String ReplaceStr(String str)
        {
            if(!String.IsNullOrWhiteSpace(str))
                return str.Replace("2016", "yyyy").Replace("2015", "yyyy").Replace("02", "mm").Replace("01", "mm").Replace("12", "mm").Replace("03", "mm");

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
            String[] temp = tBoxFolderName.Text.Split('\\');
            String folderName = temp[temp.Count() - 1];

            int numToRomove = temp.Length - 1;

            temp = temp.Take(temp.Count() - 1).ToArray();

            InsertHospital(excelList.First(), folderName, GetFileFormat(folderName), String.Join("\\", temp));
            Matching();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            InsertHospital(listView1.SelectedItems[0]);
            Matching();
        }

        private void InsertHospital(ListViewItem item)
        {
            InsertHospital(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, folderPath);
        }

        private void InsertHospital(String hosName, String folderName, String fileFormat, String folderPath)
        {
            int result = dbhandler.InsertHospital(new HospitalData(hosName, folderName, fileFormat, folderPath));
            if(result > 0)
                tBoxMsg.Text = hosName + " is inserted"; 
            else if (result < 0)
                tBoxMsg.Text = hosName + " insert is failed"; 
            
            excelList.RemoveAt(0);
        }


        /*
         * 1. 점검표 발송 리스트에서 FolderFullPath list 와 email list를 가져온다.
         * 2. FolderFullPath를 Hospital table 에서 쿼리하여 Name을 가져온다.
         * 3. Name과 EMail를 Mail Table에 Insert 한다.
         * 4. FolderFullPath list가 없으면 어쩐담?
         * 
         * */

        private void EMail()
        {
            String eMailList = PathInfo.GetExFilePath();

            Array exData;
            //(String)array.GetValue(i, 3) == "매월"
            const int HOSNAME_COL = 1;
            const int EMAIL_COL = 2;
            const int FOLDERPATH_COL = 16;

            const int ARRAY_WIDTH = 16;

            int array_height;
            //dbhandler.SelectHos();
            using (ExcelAccess servCheck = new ExcelAccess(eMailList, "aaaaaaaaa")) //open read only
            {
                servCheck.SelectSheet("병원 - 2016");
                exData = servCheck.GetRange("B2", "Q286");

                array_height = exData.Length / ARRAY_WIDTH;

                for(int i = 1; i <= array_height; i++)
                {
                    //폴더path로 쿼리하여 hosName을 찾는다.
                    String folder = ((String)exData.GetValue(i, FOLDERPATH_COL));
                    if (String.IsNullOrEmpty(folder))
                        continue;

                    List<String> hosNameList = (dbhandler.SelectHos(folder.Replace("fileserver", "Fileserver")).Count == 0 ? 
                                                dbhandler.SelectHos(folder.Replace("Fileserver", "fileserver")) : 
                                                dbhandler.SelectHos(folder.Replace("fileserver", "Fileserver")));

                    if (hosNameList.Count > 0) //Hosname과 email을 insert 한다.
                    {
                        try
                        {
                            dbhandler.InsertEMail(new EMailData(hosNameList.First(), (String)exData.GetValue(i, EMAIL_COL)));
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(hosNameList.First() + Environment.NewLine + ex.ToString());
                        }   
                    }
                }
            }
        }

        private void btnEMail_Click(object sender, EventArgs e)
        {
            EMail();
        }
        /*
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
        */
    }
}
