using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp3
{

    
    public partial class Form1 : Form
    {

        private IEnumerable<string> fileNames;
        private List<string> fileNamesList;
        private IEnumerable<string> wallPapers;
        
        private List<string> wallpapers;
        private int index = 0;
        private int wallpapersCount;
        private string dirWallpapers = "Wallpapers";
        // private Image Image;

        private bool sureClose = false;

        public Form1()
        {
            InitializeComponent();
           
        }

        bool MainFunction()
        {
            string path = OpenFileFloder();
            if (ProcessFiles(path, out string wallpaperName))
            {
                //   MessageBox.Show("lailelaodi");
                
                
                Image image = Image.FromFile(Path.Combine(Application.StartupPath, dirWallpapers, wallpaperName));
             //   MessageBox.Show("lailelaodi2");
                pictureBox1.Image = image;
            //    MessageBox.Show("lailelaodi2");
            //    image.Dispose();
          //      MessageBox.Show("lailelaodi2");
                if (DialogResult.Yes == MessageBox.Show(this, "是否设置当前最新锁屏壁纸为桌面？","确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    
                    
                    SetWallpaper(Path.Combine(Application.StartupPath, dirWallpapers, wallpaperName));
                }
                image.Dispose();
                return true;

            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="wallpaperName"></param>
        /// <returns>True if need reset wallpaper, false if not need</returns>
        private bool ProcessFiles(IEnumerable<string> files, out string wallpaperName)
        {
            if (files.Count() == 0)
            {
                wallpaperName = null;
                return false;
            }
            bool needReset = false;
            
            FileInfo fileinfo;
            List<DateTime> dateTimes = new List<DateTime>();
            DateTime dateTime = DateTime.MinValue;      //记录最新文件
            string outString = "This is a string for out!";

            foreach (var file in files)
            {
                try
                {
                    fileinfo = new FileInfo(file);

                    if (fileinfo.Length / 1024 < 200)
                    {
                        continue;   //  如果小于200kb则跳过
                    }
                    else
                    {
                        DateTime createTime = fileinfo.CreationTime;

                        string createTimeString = createTime.ToString("yyyy-MM-dd-HH-mm-ss");
                        string fileName = (createTimeString + ".jpeg");


                        Image image;
                        try
                        {
                            image = Image.FromFile(file);
                        }
                        catch (OutOfMemoryException)
                        {

                            continue;   //非图片格式 跳过
                        }


                        if (image.Width < image.Height)
                        {
                            /*如果是竖着的图片则跳过*/
                            image.Dispose();
                            continue;
                        }
                        else
                        {
                            image.Dispose();

                            try
                            {
                                                               
                                File.Copy(file, Path.Combine(Application.StartupPath, dirWallpapers, fileName));
                                //   needReset = true;       //成功拷贝新图片
                            }
                            catch (IOException)
                            {

                                if (new FileInfo(Path.Combine(Application.StartupPath, dirWallpapers, fileName)).Length != fileinfo.Length)   //  已经有一张同名图片，但不是同一张图片
                                {
                                    fileName = createTimeString + "_0.jpeg";
                                    try
                                    {
                                        
                                        File.Copy(file, Path.Combine(Application.StartupPath, dirWallpapers, fileName));
                                        //     needReset = true;
                                    }
                                    catch (IOException)
                                    {
                                        continue;   //改名后还是有相同的 跳过
                                    }


                                }
                                else
                                {
                                    continue;   //同名同图 跳过
                                }
                            }
                        }

                        //如果这个图片日期较新 则将其保存到dateTime中
                        if (dateTime < createTime)
                        {
                            dateTime = createTime;
                            outString = fileName;
                            needReset = true;
                        }

                    }
           //         MessageBox.Show("kaobeiwanle");

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); //未处理的其它异常
                    
                    wallpaperName = null;
                    return false;
                }
            }
            if (!needReset)
            {
                wallpaperName = null;
                return false;
            }
            else
            {
                wallpaperName = outString;
                return true;
            }
        }
        private bool ProcessFiles(string path, out string wallpaperName)
        {
            var files = Directory.EnumerateFiles(path);
            return ProcessFiles(files, out wallpaperName);

        }


        private void SetWallpaper(string wallpaperName)
        {
            // throw new NotImplementedException();
            [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
            if (!string.IsNullOrEmpty(wallpaperName) )
            {

                Image image2 = Image.FromFile(wallpaperName);
                //Environment.GetFolderPath(Environment.SpecialFolder.)
                string wallpaperName0 = Environment.GetEnvironmentVariable("TEMP")+@"\wallpaper.bmp";
                image2.Save(wallpaperName0);
                image2.Dispose();
                SystemParametersInfo(0x14, 0, wallpaperName0, 0x2);

            }
        }

        private string OpenFileFloder()
        {
            // throw new NotImplementedException();
            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = local + @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            return path;
          
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //  OpenFileFloder();


                var files = Directory.EnumerateFiles(OpenFileFloder());
            List<string> nowList = new List<string>(files);
            var diff = nowList.Except(fileNamesList);
                if (diff.Count() > 0)
                {
//                    fileNames = files;
                    if (ProcessFiles(diff, out string wallpaperName))
                    {

                        SetWallpaper(Path.Combine(Application.StartupPath, dirWallpapers, wallpaperName));
                    //   timer1.Enabled = true;
                    SetWallpaperList();
                    }
                }
         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Wallpapers"));
            fileNames = Directory.EnumerateFiles(OpenFileFloder());
            fileNamesList = new List<string>(fileNames);
          //  tests = Directory.EnumerateFiles(OpenFileFloder());
            LoadXlm();

            if (autoSet.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void LoadXlm()
        {
            // throw new NotImplementedException();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(Path.Combine(Application.StartupPath,"config.xml"));
            }
            catch (FileNotFoundException)
            {
                xmlDoc.Load(new StringReader("<AutoSetLockWallpaper><AutoStart></AutoStart><AutoSet></AutoSet></AutoSetLockWallpaper>"));
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
                xmlDoc.Save(Path.Combine(Application.StartupPath, "config.xml"));
                return;
            }

            XmlNode xmlNode = xmlDoc.SelectSingleNode("AutoSetLockWallpaper").SelectSingleNode("AutoStart");
            if (xmlNode.InnerText == "Yes")
            {
                autoStart.Checked = true;
            }
            else
            {
                autoStart.Checked = false;
            }

            xmlNode = xmlDoc.SelectSingleNode("AutoSetLockWallpaper").SelectSingleNode("AutoSet");
            if(xmlNode.InnerText == "Yes")
            {
                autoSet.Checked = true;
            }
            else
            {
                autoSet.Checked = false;
            }
            

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            /*
*/
        }




        private void OpenWallpaperDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", Path.Combine(Application.StartupPath, "Wallpapers"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (!sureClose)
                e.Cancel = true;
        }

        private void setNewWallpaperButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath,"Wallpapers");
            // openFileDialog.Filter = 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetWallpaper(openFileDialog.FileName);
            }

        }

        private void autoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (autoStart.Checked)
            {
                try
                {
                    RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\MicroSoft\Windows\CurrentVersion\Run");
                    registry.SetValue("AutoSetLockScreenWallpaperToDesktopWallpaper", Application.ExecutablePath);

                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }

            }
            else
            {
                RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\MicroSoft\Windows\CurrentVersion\Run");
                registry.DeleteValue("AutoSetLockScreenWallpaperToDesktopWallpaper");
            }
            SetXml("AutoStart", autoStart.Checked);
        }

        private void SetXml(string v, bool @checked)
        {
            //throw new NotImplementedException();
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(Path.Combine(Application.StartupPath, "config.xml"));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("xml没了!!!");
                return;
            }

            XmlNode xmlNode = xmlDocument.SelectSingleNode("AutoSetLockWallpaper").SelectSingleNode(v);
            if (@checked)
            {
                xmlNode.InnerText = "Yes";
            }
            else
            {
                xmlNode.InnerText = "No";
            }
            xmlDocument.Save(Path.Combine(Application.StartupPath, "config.xml"));

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this,"关闭程序后将不能自动将锁屏设置为壁纸，确定吗？","确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                sureClose = true;
                Application.Exit();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void autoSetWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSet.Checked)
            {
                timer1.Enabled = true;
         //       MessageBox.Show("enabled");
            }
            else
            {
                timer1.Enabled = false;
            }
            SetXml("AutoSet", autoSet.Checked);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bool isFirstShow = MainFunction();
            SetWallpaperList();

            if (!isFirstShow)
            {
                if (wallpapers.Count() > 0)
                {
                    pictureBox1.Image = Image.FromFile(wallpapers[index]);
                }

            }
            else
            {
                index = wallpapersCount - 1;
            }


        }

        private void SetWallpaperList()
        {
            //throw new NotImplementedException();
            wallPapers = Directory.EnumerateFiles(Path.Combine(Application.StartupPath,"Wallpapers"));
            wallpapers = wallPapers.ToList();
            wallpapersCount = wallpapers.Count;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (++index > wallpapersCount-1)
                {
                    index = 0;
                }
  
            }
            else if(e.Button == MouseButtons.Right)
            {
                if (--index < 0)
                {
                    index = wallpapersCount - 1;
                }
               // pictureBox1.Image = Image.FromFile(wallpapers[index]);
            }else if(e.Button == MouseButtons.Middle)
            {
                SetWallpaper(wallpapers[index]);
            }
            Image image = Image.FromFile(wallpapers[index]);
              Stream stream = new MemoryStream();
              image.Save(stream, ImageFormat.Bmp);
            image.Dispose();
            
            pictureBox1.Image = Image.FromStream(stream);
              stream.Dispose();
            stream.Close();
           // image.Dispose();

        }



        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox1, "左键下一张，右键上一张，中键设置为桌面");
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                SetWallpaper(wallpapers[index]);
            }
        }
    }

}
